namespace VisualSearch
{
    public static class SearchUtils
    {
        public static string SubMatch(string str, int pos)
        {
            return pos > str.Length - 77 ?
                "..." + str.Substring(str.Length - 77) :
                "..." + str.Substring(pos, 74) + "...";
        }

        public static bool IsEmpty(string str)
        {
            return (string.IsNullOrEmpty(str) || str.Trim() == string.Empty);
        }
    }
}
