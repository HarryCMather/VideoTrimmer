using System;
using System.Globalization;
using System.Windows.Forms;
using VideoTrimmer.Statistics;

namespace VideoTrimmer
{
    public partial class Form1 : Form
    {
        private readonly BitrateCalculator _bitrateCalculator;

        private double? startDurationSeconds;
        private double? endDurationSeconds;

        public Form1(BitrateCalculator bitrateCalculator)
        {
            _bitrateCalculator = bitrateCalculator;
            InitializeComponent();
        }

        private void chooseVideoButton_Click(object sender, EventArgs e)
        {
            const string filePath = "C:\\Users\\harry\\Videos\\Nvidia Share\\Counter-strike  Global Offensive\\Counter-strike  Global Offensive 2023.02.08 - 19.29.36.82.DVR.mp4";
            videoPlayer.URL = filePath;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startDurationSeconds = videoPlayer.Ctlcontrols.currentPosition;
            startDurationLabel.Text = Math.Round(startDurationSeconds.Value, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            endDurationSeconds = videoPlayer.Ctlcontrols.currentPosition;
            endDurationLabel.Text = Math.Round(endDurationSeconds.Value, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
        }

        private void compressAndTrimButton_Click(object sender, EventArgs e)
        {
            if (startDurationSeconds == null || endDurationSeconds == null) return;

        }
    }
}
