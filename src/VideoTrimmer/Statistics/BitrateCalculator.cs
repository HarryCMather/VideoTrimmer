using VideoTrimmer.ffMPEG;

namespace VideoTrimmer.Statistics
{
    public class BitrateCalculator
    {
        private const double MaxSizeMB = 7.5;

        public double CalculateTotalBitrate(double trimmedVideoDurationSeconds, string filePath)
        {
            // Assume input is in Mbps, though this may need to be adjusted...
            double audioBitrateKbps = ffMPEGWrapper.GetAudioBitrate(filePath);
            double availableVideoSizeMB = MaxSizeMB - CalculateAudioSize(trimmedVideoDurationSeconds, audioBitrateKbps);
            return CalculateVideoBitrate(trimmedVideoDurationSeconds, availableVideoSizeMB);
        }

        private static double CalculateAudioSize(double trimmedVideoDurationSeconds, double audioBitrateKbps)
        {
            return ((trimmedVideoDurationSeconds * audioBitrateKbps) / 8.0) / 1000.0;
        }

        private static double CalculateVideoBitrate(double trimmedVideoDurationSeconds, double availableVideoSizeMB)
        {
            return (availableVideoSizeMB / trimmedVideoDurationSeconds) * 8.0;
        }
    }
}
