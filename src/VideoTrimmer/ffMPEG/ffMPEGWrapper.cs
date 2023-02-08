using System.Diagnostics;
using System.IO;

namespace VideoTrimmer.ffMPEG
{
    public static class ffMPEGWrapper
    {
        public static double GetAudioBitrate(string filePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "ffprobe.exe",
                Arguments = $"-v 0 -select_streams a:0 -show_entries stream=bit_rate -of compact=p=0:nk=1 \"{filePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            string standardOutput;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                using (StreamReader streamReader = process.StandardOutput)
                {
                    standardOutput = streamReader.ReadToEnd();
                }

                process.WaitForExit();
            }

            return double.Parse(standardOutput) / 1000;
        }

        public static void CompressVideo(string inputFilePath)
        {
            string fileName = Path.GetFileName(inputFilePath);
            string extension = fileName.Replace(Path.GetFileNameWithoutExtension(inputFilePath), string.Empty);

            string outputFilePath = $"{inputFilePath.Replace(fileName, $"{fileName}-Trimmed{extension}")}";

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "ffmpeg.exe",
                Arguments = "ADD THIS...",
                UseShellExecute = false,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();
            }
        }
    }
}
