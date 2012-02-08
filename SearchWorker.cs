using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace VisualSearch
{
    public class SearchWorker
    {
        public event ProgressChangedEventHandler ProgressChanged;
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;

        private BackgroundWorker worker;

        private object isRunningLock = new object();
        private bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { lock (isRunningLock) { isRunning = value; } }
        }

        public SearchWorker()
        {
            worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public void Execute(SearchCriteria searchCriteria)
        {
            worker.RunWorkerAsync(searchCriteria);
        }

        public void StopNow()
        {
            if (worker.IsBusy && !worker.CancellationPending)
            {
                worker.CancelAsync();
            }
            else
            {
                IsRunning = false;
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsRunning = true; 
            SearchCriteria sc = e.Argument as SearchCriteria;
            if (sc == null) return;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                e.Result = "Search was cancelled";
                return;
            }
            try
            {
                worker.ReportProgress(0, "Retrieving list of files");
                SearchOption searchOption = sc.InSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                double count, total;
#if CLRVER3_5 || CLVER4_0
                var files = new HashSet<string>();
                {
                    string[] filters = sc.Filter.Split(';');
                    foreach (string filter in filters)
                        files.UnionWith(Directory.GetFiles(sc.Folder, filter, searchOption));
                }
                if (!SearchUtils.IsEmpty(sc.Exclude))
                {
                    string[] excluded = sc.Exclude.Split(';');
                    foreach (string exclude in excluded)
                        files.ExceptWith(Directory.GetFiles(sc.Folder, exclude, searchOption));
                }
#else
                Dictionary<string, object> excl = null;
                if (!SearchUtils.IsEmpty(sc.Exclude))
                {
                    excl = new Dictionary<string, object>();
                    string[] excluded = sc.Exclude.Split(';');
                    foreach (string exclude in excluded)
                    {
                        var exclFiles = Directory.GetFiles(sc.Folder, exclude, searchOption);
                        count = 0D;
                        total = exclFiles.LongLength;
                        foreach (var file in exclFiles)
                        {
                            if (!excl.ContainsKey(file))
                            {
                                worker.ReportProgress((int)(++count * 100D / total), "Excluding file " + file);
                                excl.Add(file, null);
                            }
                        }
                    }
                }
                var incl = new Dictionary<string, object>();
                string[] filters = sc.Filter.Split(';');
                foreach (string filter in filters)
                {
                    var incFiles = Directory.GetFiles(sc.Folder, filter, searchOption);
                    count = 0D;
                    total = incFiles.LongLength;
                    foreach (var file in incFiles)
                    {
                        if (!incl.ContainsKey(file) && (excl == null || !excl.ContainsKey(file)))
                        {
                            worker.ReportProgress((int)(++count * 100D / total), "Adding file " + file);
                            incl.Add(file, null);
                        }
                    }
                }
                var files = incl.Keys;
#endif
                double incr = 100d / (double)files.Count;
                total = 0d;
                int fileCount = 0, matchCount = 0, position;
                bool fileMatch;
                SearchEngine engine = new SearchEngine(sc);
                foreach (string file in files)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        e.Result = "Search was cancelled";
                        return;
                    }
                    total += incr;
                    worker.ReportProgress((int)total, "Searching " + Path.GetFileName(file));
                    string[] lines = File.ReadAllLines(file);
                    fileMatch = false;
                    int matchLimit = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (worker.CancellationPending)
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
                                lines[i].Length <= 80 ? lines[i] : SearchUtils.SubMatch(lines[i], position));
                            worker.ReportProgress((int)total, match);
                            if (++matchLimit >= 100)
                                break;
                        }
                    }
                    if (fileMatch) fileCount++;
                }
                worker.ReportProgress(100, "Search complete.");
                e.Result = string.Format("Searched {0} files. Found {1} matches in {2} files.",
                    files.Count, matchCount, fileCount);
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(sender, e);
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
            if (RunWorkerCompleted != null)
            {
                RunWorkerCompleted(sender, e);
            }
        }
    }
}
