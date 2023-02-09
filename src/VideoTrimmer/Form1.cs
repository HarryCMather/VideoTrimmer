using System;
using System.Globalization;
using System.Windows.Forms;
using VideoTrimmer.ffMPEG;
using VideoTrimmer.FileManagement;
using VideoTrimmer.Statistics;

namespace VideoTrimmer
{
    public partial class Form1 : Form
    {
        private readonly IStatistics _statistics;
        private readonly IFileValidator _fileValidator;

        private double? startDurationSeconds;
        private double? endDurationSeconds;
        private string filePath = string.Empty;

        public Form1(IStatistics statistics, IFileValidator fileValidator)
        {
            _statistics = statistics;
            _fileValidator = fileValidator;

            InitializeComponent();

            videoPlayer.settings.autoStart = false;
        }

        private void chooseVideoButton_Click(object sender, EventArgs e)
        {
            if (videoOpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(@"Error: A valid file was not specified");
                return;
            }

            filePath = videoOpenFileDialog.FileName;

            if (!_fileValidator.ValidateFile(filePath))
            {
                startButton.Enabled = false;
                startButton.Visible = false;

                endButton.Enabled = false;
                endButton.Visible = false;
                return;
            }

            videoPlayer.URL = filePath;
            videoPlayer.Ctlcontrols.pause();

            startButton.Enabled = true;
            startButton.Visible = true;

            endButton.Enabled = true;
            endButton.Visible = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startDurationSeconds = Math.Round(videoPlayer.Ctlcontrols.currentPosition, 3, MidpointRounding.AwayFromZero);
            startDurationLabel.Text = $@"{startDurationSeconds.Value.ToString(CultureInfo.InvariantCulture)} s";

            ValidateStartAndEndDuration();
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            endDurationSeconds = Math.Round(videoPlayer.Ctlcontrols.currentPosition, 3, MidpointRounding.AwayFromZero);
            endDurationLabel.Text = $@"{endDurationSeconds.Value.ToString(CultureInfo.InvariantCulture)} s";

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
            // This will never be null, as the button will never be visible when null.
            double duration = _statistics.CalculateDuration(startDurationSeconds.Value, endDurationSeconds.Value);
            double videoBitrate = _statistics.CalculateTotalBitrate(duration, filePath);

            (string startTimeStamp, string endTimeStamp) = _statistics.CalculateTimeStamps(startDurationSeconds.Value, endDurationSeconds.Value);

            ffMPEGWrapper.CompressVideo(filePath, videoBitrate, startTimeStamp, endTimeStamp);
        }
    }
}
