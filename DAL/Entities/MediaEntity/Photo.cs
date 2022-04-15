using DAL.Entities.MediaEntity.Base;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace DAL.Entities.MediaEntity
{
    public class Photo : FileBase
    {
        public Photo(string path) : base(path)
        {
        }
    }
}
