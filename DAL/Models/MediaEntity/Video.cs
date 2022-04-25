using DAL.Models.MediaEntity.Base;
using Xabe.FFmpeg;

namespace DAL.Models.MediaEntity
{
    public class Video : FileBase
    {
        public Video(string path) : base(path)
        {
        }

        public TimeSpan Duration => FFmpeg.GetMediaInfo(Path).Result.Duration;

        public override string ToString()
        {
            return base.ToString() +
                $"\n  Duration: {Duration}";
        }
    }
}
