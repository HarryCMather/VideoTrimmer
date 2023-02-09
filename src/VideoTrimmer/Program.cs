using System;
using System.Windows.Forms;
using VideoTrimmer.FileManagement;
using VideoTrimmer.Statistics;

namespace VideoTrimmer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IStatistics statistics = new Statistics.Statistics();
            IFileValidator fileValidator = new FileValidator();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(statistics, fileValidator));
        }
    }
}
