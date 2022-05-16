using ViewModels.MediaViewModels.Base;
using Xabe.FFmpeg;

namespace ViewModels.MediaViewModels
{
    public class VideoViewModel : FileViewModel
    {
        public TimeSpan Duration => FFmpeg.GetMediaInfo(Path).Result.Duration;

        public override string ToString()
        {
            return base.ToString() +
                $"\n  Duration: {Duration}";
        }
    }
}
