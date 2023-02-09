using System;
using VideoTrimmer.ffMPEG;

namespace VideoTrimmer.Statistics
{
    public class Statistics : IStatistics
    {
        private const double MaxSizeMB = 7.5;

        public double CalculateTotalBitrate(double trimmedVideoDurationSeconds, string filePath)
        {
            double audioBitrateKbps = ffMPEGWrapper.GetAudioBitrate(filePath);
            double availableVideoSizeMB = MaxSizeMB - CalculateAudioSize(trimmedVideoDurationSeconds, audioBitrateKbps);
            return CalculateVideoBitrate(trimmedVideoDurationSeconds, availableVideoSizeMB) * 1000;
        }

        private static double CalculateAudioSize(double trimmedVideoDurationSeconds, double audioBitrateKbps)
        {
            return ((trimmedVideoDurationSeconds * audioBitrateKbps) / 8.0) / 1000.0;
        }

        private static double CalculateVideoBitrate(double trimmedVideoDurationSeconds, double availableVideoSizeMB)
        {
            return (availableVideoSizeMB / trimmedVideoDurationSeconds) * 8.0;
        }

        public (string startTimeStamp, string endTimeStamp) CalculateTimeStamps(double startDurationSeconds, double endDurationSeconds)
        {
            string startTimeStamp = TimeSpan.FromSeconds(startDurationSeconds).ToString("c");
            string endTimeStamp = TimeSpan.FromSeconds(endDurationSeconds).ToString("c");
            return (startTimeStamp, endTimeStamp);
        }

        public double CalculateDuration(double startDurationSeconds, double endDurationSeconds)
        {
            return endDurationSeconds - startDurationSeconds;
        }
    }
}
