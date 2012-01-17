using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VisualSearch
{
    public partial class MainSearch : Form
    {

        // Const values
        private const int MAX_COMBOBOX_ITEMS = 20; // Number of items to remember in a combo box.   


        private BindingList<CMatch> matches;
        private string StartingFolder { get; set; }
        private String StartingSearch { get; set; }
        private bool DebugOnStart { get; set; }

        public MainSearch()
        {
            InitializeComponent();

        }

        public MainSearch(string[] args, string input)
            : this()
        {
            ParseArguments(args, input);
            SetLocation();
        }

        private void ParseArguments(string[] args, string input)
        {
            StartingFolder = "";
            StartingSearch = "";
            DebugOnStart = false;
            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if ("/folder".Equals(args[i], StringComparison.CurrentCultureIgnoreCase) &&
                        i < args.Length - 1 && !string.IsNullOrEmpty(args[i + 1]) &&
                        Directory.Exists(args[i + 1]))
                    {
                        StartingFolder = Path.GetFullPath(args[++i]);
                    }
                    else if ("/debug".Equals(args[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        DebugOnStart = true;
                    }
                }
            }
            if (!string.IsNullOrEmpty(input))
            {
                StartingSearch = input.Split('\r', '\n', '\x1A')[0];
            }
        }

        private void SetLocation()
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
        }

        private static bool IsEmpty(string str)
        {
            return (string.IsNullOrEmpty(str) || str.Trim() == string.Empty);
        }

        private void Message(string message)
        {
            lblSearch.Text = message;
            if (chkDebug.Checked)
            {
                txtDebug.Text += message + "\r\n";
            }
        }

        private static void AddQuickSearchItem(ComboBox box)
        {
            if (box == null || string.IsNullOrEmpty(box.Text)) return;
            var current = box.Text;
            if (box.Items.Contains(current)) return;
            box.Items.Insert(0, current);
            if (box.Items.Count <= MAX_COMBOBOX_ITEMS) return;
            for (var i = box.Items.Count; i > MAX_COMBOBOX_ITEMS; i--)
                box.Items.RemoveAt(MAX_COMBOBOX_ITEMS);
        }

        private void AddQuickSearchItems()
        {
            AddQuickSearchItem(cmbFind);
            AddQuickSearchItem(cmbFilters);
            AddQuickSearchItem(cmbExclude);
            AddQuickSearchItem(cmbDirectory);
        }

        private bool IsValid()
        {
            if (IsEmpty(cmbFind.Text) || IsEmpty(cmbDirectory.Text) || IsEmpty(cmbFilters.Text))
            {
                Message("Text to find, filter and directory are required.");
                return false;
            }
            if (!Directory.Exists(cmbDirectory.Text))
            {
                Message("Folder doesn't exist: " + cmbDirectory.Text);
                return false;
            }
            if (cmbFilters.Text.Trim() == ";" || cmbExclude.Text.Trim() == ";")
            {
                Message("Invalid Filters");
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;
            AddQuickSearchItems();
            SetFormCaption(cmbDirectory.Text);
            txtDebug.Text = "";
            matches = new BindingList<CMatch>();
            grdResults.DataSource = matches;
            var sc = new SearchCriteria
            {
                Find = cmbFind.Text,
                Folder = cmbDirectory.Text,
                Filter = cmbFilters.Text,
                Exclude = cmbExclude.Text,
                InSubFolders = chkSub.Checked,
                CaseSensitive = chkCase.Checked,
                WholeWords = chkWhole.Checked
            };
            if (rbRegex.Checked) sc.SearchMode = SearchCriteria.SearchModes.RegEx;
            else if (rbExtended.Checked) sc.SearchMode = SearchCriteria.SearchModes.Extended;
            else sc.SearchMode = SearchCriteria.SearchModes.Normal;
            wrkSearch.RunWorkerAsync(sc);
            btnSearch.Enabled = false;
            btnClose.Text = "Cancel";
        }

        private void wrkSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchCriteria sc = e.Argument as SearchCriteria;
            if (sc == null) return;
            if (wrkSearch.CancellationPending)
            {
                e.Cancel = true;
                e.Result = "Search was cancelled";
                return;
            }
            try
            {
                wrkSearch.ReportProgress(0, "Retrieving list of files");
                SearchOption searchOption = sc.InSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                var files = new HashSet<string>();
                {
                    string[] filters = sc.Filter.Split(';');
                    foreach (string filter in filters)
                        files.UnionWith(Directory.GetFiles(sc.Folder, filter, searchOption));
                }
                if (!IsEmpty(sc.Exclude))
                {
                    string[] excluded = sc.Exclude.Split(';');
                    foreach (string exclude in excluded)
                        files.ExceptWith(Directory.GetFiles(sc.Folder, exclude, searchOption));
                }
                double incr = 100d / (double)files.Count;
                double total = 0d;
                int fileCount = 0, matchCount = 0, position;
                bool fileMatch;
                SearchEngine engine = new SearchEngine(sc);
                foreach (string file in files)
                {
                    if (wrkSearch.CancellationPending)
                    {
                        e.Cancel = true;
                        e.Result = "Search was cancelled";
                        return;
                    }
                    total += incr;
                    wrkSearch.ReportProgress((int)total, "Searching " + Path.GetFileName(file));
                    string[] lines = File.ReadAllLines(file);
                    fileMatch = false;
                    int matchLimit = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (wrkSearch.CancellationPending)
                        {
                            e.Cancel = true;
                            e.Result = "Search was cancelled";
                            return;
                        }
                        position = engine.Search(lines[i]);
                        if (position >= 0)
                        {
                            matchCount++;
                            fileMatch = true;
                            CMatch match = new CMatch(Path.GetFullPath(file), i + 1,
                                lines[i].Length <= 80 ? lines[i] : SubMatch(lines[i], position));
                            wrkSearch.ReportProgress((int)total, match);
                            if (++matchLimit >= 100)
                                break;
                        }
                    }
                    if (fileMatch) fileCount++;
                }
                e.Result = string.Format("Searched {0} files. Found {1} matches in {2} files.",
                    files.Count, matchCount, fileCount);
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private static string SubMatch(string str, int pos)
        {
            return pos > str.Length - 77 ?
                "..." + str.Substring(str.Length - 77) :
                "..." + str.Substring(pos, 74) + "...";
        }

        private void wrkSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barSearch.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                CMatch match = e.UserState as CMatch;
                if (match == null)
                {
                    Message((string)e.UserState);
                }
                else
                {
                    matches.Add(match);
                }
            }
        }

        private void wrkSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Message("Search was cancelled");
            }
            else if (e.Result != null)
            {
                Message((string)e.Result);
            }
            btnSearch.Enabled = true;
            btnClose.Text = "Close";
        }

        private void btnSelDir_Click(object sender, EventArgs e)
        {
            fileSelDir.InitialDirectory = !string.IsNullOrEmpty(cmbDirectory.Text) ?
                cmbDirectory.Text : !string.IsNullOrEmpty(fileSelDir.InitialDirectory) ?
                fileSelDir.InitialDirectory : Environment.CurrentDirectory;
            fileSelDir.FileName = "\n";
            if (fileSelDir.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    cmbDirectory.Text = Path.GetFullPath(fileSelDir.FileName);
                }
                catch (ArgumentException) { }
            }
        }

        private void grdResults_DoubleClick(object sender, EventArgs e)
        {
            if (grdResults.SelectedRows.Count <= 0) return;
            var row = grdResults.SelectedRows[0];
            // Change this if you want the double click action to do something different
            // instead of opening EditPad Pro.
            Process.Start("EditPadPro", string.Format("\"{0}\" /l{1}",
                row.Cells["FullPath"].Value, row.Cells["Line"].Value));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (wrkSearch.IsBusy && !wrkSearch.CancellationPending)
            {
                wrkSearch.CancelAsync();
            }
            else if (MessageBox.Show("Confirm Exit?", "Exit Search",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void chkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;
        }

        private void MainSearch_Activated(object sender, EventArgs e)
        {
            if (this.Opacity != 1d)
                this.Opacity = 1d;
        }

        private void MainSearch_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost)
                this.Opacity = 0.5;
        }

        private void MainSearch_Load(object sender, EventArgs e)
        {
            cmbDirectory.Text = StartingFolder;
            cmbFind.Text = StartingSearch;
            chkDebug.Checked = DebugOnStart;
            Message("Input:<" + StartingSearch + ">");
            SetFormCaption(StartingFolder);
        }

        private void SetFormCaption(string text)
        {
            this.Text = "Visual Search" + (string.IsNullOrEmpty(text) ?
                "" : " - " + text);
        }
    }
}
