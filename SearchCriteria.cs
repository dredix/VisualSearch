namespace VisualSearch
{
    public class SearchCriteria
    {
        public enum SearchModes
        {
            Normal,
            Extended,
            RegEx
        }

        public string Find { get; set; }
        public string Folder { get; set; }
        public string Filter { get; set; }
        public string Exclude { get; set; }
        public bool InSubFolders { get; set; }
        public bool CaseSensitive { get; set; }
        public bool WholeWords { get; set; }
        public SearchModes SearchMode { get; set; }
    }
}
