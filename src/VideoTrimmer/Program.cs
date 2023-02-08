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
            IBitrateCalculator bitrateCalculator = new BitrateCalculator();
            IFileValidator fileValidator = new FileValidator();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(bitrateCalculator, fileValidator));
        }
    }
}
