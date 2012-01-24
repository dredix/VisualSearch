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
        private SearchWorker searchWorker;

        public MainSearch()
        {
            InitializeComponent();

        }

        public MainSearch(string[] args, string input)
            : this()
        {
            ParseArguments(args, input);
            SetLocation();
            searchWorker = new SearchWorker();
            searchWorker.ProgressChanged += searchWorker_ProgressChanged;
            searchWorker.RunWorkerCompleted += searchWorker_RunWorkerCompleted;
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
            if (SearchUtils.IsEmpty(cmbFind.Text) || SearchUtils.IsEmpty(cmbDirectory.Text) || SearchUtils.IsEmpty(cmbFilters.Text))
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
            searchWorker.Execute(sc);
            btnSearch.Enabled = false;
            btnClose.Text = "Cancel";
        }

        private void searchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private void searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            if (searchWorker.IsRunning)
            {
                searchWorker.StopNow();
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
