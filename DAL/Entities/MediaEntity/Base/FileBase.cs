using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.MediaEntity.Base
{
    [NotMapped]
    public abstract class FileBase
    {
        private string _path = string.Empty;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (!Directory.Exists(value))
                {
                    throw new FileNotFoundException();
                }
                _path = value;
            }
        }
        public string Name => new FileInfo(Path).Name;
        public string Format => new FileInfo(Path).Extension;
        public string Size => (double)(new FileInfo(Path).Length * 1024 * 1024 / 1048576) + "Mb";
        public FileBase(string path)
        {
            Path = path;
        }
        public override string ToString()
        {
            return $"  Name: {Name}" +
                $"\n  Format: {Format}" +
                $"\n  Size: {Size}";
                
        }
    }
}
