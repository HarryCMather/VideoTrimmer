using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTrimmer
{
    public partial class Form1 : Form
    {
        private readonly Statistics _statistics;

        private double? startDurationSeconds;
        private double? endDurationSeconds;

        public Form1(Statistics statistics)
        {
            _statistics = statistics;
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
            MessageBox.Show($@"{_statistics.CalculateTotalBitrate(10.0, 128)}");

            if (startDurationSeconds == null || endDurationSeconds == null) return;

            MessageBox.Show($@"Start: {startDurationSeconds}, End: {endDurationSeconds}");
        }
    }
}
