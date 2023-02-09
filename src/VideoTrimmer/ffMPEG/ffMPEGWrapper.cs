using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static async Task CompressVideo(string inputFilePath, double videoBitrate, string startTimeStamp, string endTimeStamp)
        {
            string fileName = Path.GetFileName(inputFilePath);
            string extension = fileName.Replace(Path.GetFileNameWithoutExtension(inputFilePath), string.Empty);

            string outputFilePath = $"{inputFilePath.Replace(fileName, $"{fileName}-Trimmed{extension}")}";

            MessageBox.Show(videoBitrate.ToString(CultureInfo.InvariantCulture));

            await Task.Run(() =>
            {
                //string output = string.Empty;

                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = "ffmpeg.exe",
                    Arguments = $"-y -vsync passthrough -hwaccel cuda -i \"{inputFilePath}\" -ss {startTimeStamp} -to {endTimeStamp} -max_muxing_queue_size 9999 -pix_fmt yuv420p " +
                                $"-c:v h264_nvenc -preset slow -tune hq -b:v {videoBitrate}K -bufsize 1M -maxrate {videoBitrate}K -qmin 0 -vf scale=\"1920:-1\" -c:a copy \"{outputFilePath}\"",
                    UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //RedirectStandardError = true,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    //using (StreamReader streamReader = process.StandardOutput)
                    //{
                    //    output += streamReader.ReadToEnd();
                    //}

                    //using (StreamReader streamReader = process.StandardError)
                    //{
                    //    output += streamReader.ReadToEnd();
                    //}

                    process.WaitForExit();

                    //MessageBox.Show(output);
                }
            }).ConfigureAwait(false);
        }
    }
}
