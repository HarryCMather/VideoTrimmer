namespace VideoTrimmer.Statistics
{
    public interface IStatistics
    {
        double CalculateTotalBitrate(double trimmedVideoDurationSeconds, string filePath);

        (string startTimeStamp, string endTimeStamp) CalculateTimeStamps(double startDurationSeconds, double endDurationSeconds);

        double CalculateDuration(double startDurationSeconds, double endDurationSeconds);
    }
}
