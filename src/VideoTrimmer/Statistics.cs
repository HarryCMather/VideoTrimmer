using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTrimmer
{
    public class Statistics
    {
        private const double MaxSizeMB = 7.5;

        public double CalculateTotalBitrate(double trimmedVideoDurationSeconds, double audioBitrateKbps)
        {
            // Assume input is in Mbps, though this may need to be adjusted...
            double availableVideoSizeMB = MaxSizeMB - CalculateAudioSize(trimmedVideoDurationSeconds, audioBitrateKbps);
            return CalculateVideoBitrate(trimmedVideoDurationSeconds, availableVideoSizeMB);
        }

        private double CalculateAudioSize(double trimmedVideoDurationSeconds, double audioBitrateKbps)
        {
            return ((trimmedVideoDurationSeconds * audioBitrateKbps) / 8.0) / 1024.0;
        }

        private double CalculateVideoBitrate(double trimmedVideoDurationSeconds, double availableVideoSizeMB)
        {
            return (availableVideoSizeMB / trimmedVideoDurationSeconds) * 8.0;
        }
    }
}
