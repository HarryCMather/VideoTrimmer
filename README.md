# VideoTrimmer
A tool for trimming and compressing clips, designed for use with Discord due to its restrictive file size limit of 8MB.  This program will allow users to specify a start and end duration, then automatically calculate the required bitrate to maintain the 8MB file limit, before performing the clip trimming with ffmpeg.

# Prerequisites
- .NET Framework 4.7.2 runtime is required, as Windows Forms in .NET Core does not natively support Video Players.
- A Nvidia GPU that supports CUDA and NVENC Encoding.

# Planned changes
- Bug fix: Output file name contains the file extension twice. (This should also live within the FileManagment class, rather than ffMPEG wrapper)
- Potential bug fix: Output videos are often smaller than 7MB, smaller sizes resutls in lower quality.  Investigate whether anything can make this closer to the file size target.
- Add a check for any hardware accelerated encoders with a software fallback option, rather than only supporting Nvidia GPUs.
- Add the ability to specify a target file size other than 8MB.
- Move some of the ffMPEG options as a choice on-screen to allow for better flexibility.
