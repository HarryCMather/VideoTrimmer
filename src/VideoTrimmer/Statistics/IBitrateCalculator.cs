namespace VideoTrimmer.Statistics
{
    public interface IBitrateCalculator
    {
        double CalculateTotalBitrate(double trimmedVideoDurationSeconds, string filePath);
    }
}
