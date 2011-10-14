using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VisualSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string input = Console.In.ReadToEnd();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainSearch(args, input));
        }
    }
}
