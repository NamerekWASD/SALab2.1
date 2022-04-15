using DAL.Entities.MediaEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace DAL.Entities.MediaEntity
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
