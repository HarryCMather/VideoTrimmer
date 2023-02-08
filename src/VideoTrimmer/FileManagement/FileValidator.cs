using System;
using System.IO;
using System.Linq;

namespace VideoTrimmer.FileManagement
{
    public class FileValidator : IFileValidator
    {
        public string[] ValidFileTypes =
        {
            "mkv", "mp4", "m4v", "webm", "flv", "avi", "mov"
        };

        public bool ValidateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            return ValidFileTypes.Any(validFileType => filePath.EndsWith(validFileType, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
