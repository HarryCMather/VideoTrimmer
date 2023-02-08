using System;
using System.Globalization;
using System.Windows.Forms;
using VideoTrimmer.FileManagement;
using VideoTrimmer.Statistics;

namespace VideoTrimmer
{
    public partial class Form1 : Form
    {
        private readonly IBitrateCalculator _bitrateCalculator;
        private readonly IFileValidator _fileValidator;

        private double? startDurationSeconds;
        private double? endDurationSeconds;

        public Form1(IBitrateCalculator bitrateCalculator, IFileValidator fileValidator)
        {
            _bitrateCalculator = bitrateCalculator;
            _fileValidator = fileValidator;
            InitializeComponent();
        }

        private void chooseVideoButton_Click(object sender, EventArgs e)
        {
            // TODO: Replace this with a open file dialogue...
            const string filePath = "C:\\Users\\harry\\Videos\\Nvidia Share\\Counter-strike  Global Offensive\\Counter-strike  Global Offensive 2023.02.08 - 19.29.36.82.DVR.mp4";

            if (!_fileValidator.ValidateFile(filePath))
            {
                startButton.Enabled = false;
                startButton.Visible = false;

                endButton.Enabled = false;
                endButton.Visible = false;
                return;
            }

            videoPlayer.URL = filePath;

            startButton.Enabled = true;
            startButton.Visible = true;

            endButton.Enabled = true;
            endButton.Visible = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startDurationSeconds = videoPlayer.Ctlcontrols.currentPosition;
            startDurationLabel.Text = Math.Round(startDurationSeconds.Value, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);

            ValidateStartAndEndDuration();
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            endDurationSeconds = videoPlayer.Ctlcontrols.currentPosition;
            endDurationLabel.Text = Math.Round(endDurationSeconds.Value, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);

            ValidateStartAndEndDuration();
        }

        public void ValidateStartAndEndDuration()
        {
            if (startDurationSeconds == null || endDurationSeconds == null || startDurationSeconds >= endDurationSeconds)
            {
                compressAndTrimButton.Enabled = false;
                compressAndTrimButton.Visible = false;
                return;
            }

            compressAndTrimButton.Enabled = true;
            compressAndTrimButton.Visible = true;
        }

        private void compressAndTrimButton_Click(object sender, EventArgs e)
        {

        }
    }
}
