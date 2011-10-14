using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VisualSearch
{
    public class SearchEngine
    {

        private SearchCriteria criteria;
        private string toFind;
        private StringComparison comparisonType;
        private Regex expression;

        public SearchEngine(SearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("Criteria cannot be null");
            this.criteria = criteria;
            PrepareEngine();
        }

        private void PrepareEngine()
        {
            toFind = criteria.Find;
            if (criteria.SearchMode == SearchCriteria.SearchModes.RegEx)
            {
                if (criteria.WholeWords)
                    toFind = @"\W" + toFind + @"\W";
                expression = new Regex(toFind, RegexOptions.Compiled | 
                    RegexOptions.CultureInvariant | 
                    (criteria.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase));
                return;
            }
            if (criteria.SearchMode == SearchCriteria.SearchModes.Extended)
            {
                string text = toFind.Replace(@"\t", "\t");
                MatchCollection matches = Regex.Matches(text,
                    @"\\x[0-9a-f]{2}", RegexOptions.IgnoreCase);
                foreach (Match m in matches)
                {
                    char c = (char)(Convert.ToInt32(m.Value.Substring(2), 16) & 0xFF);
                    text = text.Replace(m.Value, c.ToString());
                }
                toFind = text;
            }
            comparisonType = criteria.CaseSensitive ?
                        StringComparison.InvariantCulture :
                        StringComparison.InvariantCultureIgnoreCase;

            if (criteria.WholeWords)
            {
                expression = new Regex(@"\w+", RegexOptions.Compiled |
                    RegexOptions.CultureInvariant |
                    (criteria.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase));
            }
        }

        public int Search(string text)
        {
            if (string.IsNullOrEmpty(text))
                return -1;
            if (criteria.SearchMode == SearchCriteria.SearchModes.RegEx)
            {
                Match m = expression.Match(text);
                return m.Success ? m.Index : -1;
            }
            else if (criteria.WholeWords)
            {
                var matches = expression.Matches(text);
                foreach (Match m in matches)
                {
                    if (toFind.Equals(m.Value, comparisonType)) 
                        return m.Index;
                }
                return -1;
            }
            return text.IndexOf(toFind, 0, comparisonType);
        }


    }
}
