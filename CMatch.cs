using System.IO;

namespace VisualSearch
{
    public class CMatch
    {
        public string Filename { get; private set; }
        public int Line { get; set; }
        public string Text { get; set; }
        public string FullPath { get; set; }

        public CMatch(string fullPath, int line, string text)
        {
            Line = line;
            Text = text;
            FullPath = fullPath;
            Filename = Path.GetFileName(FullPath);
        }
    }
}
