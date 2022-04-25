using DAL.Models.MediaEntity.Base;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.MediaEntity.MatchingToPlace
{
    public class FileContainer
    {
        public int Id { get; set; }
        private string _path;
        [NotMapped]
        private FileBase _file;
        [NotMapped]
        public FileBase File
        {
            private get
            {
                _file.Path = _path;
                return _file;
            }

            set
            {
                _file = value;
            }
        }
        public string Path { set { _path = value; } }
        public override string ToString()
        {
            return File.ToString()
                + $"\n  Person who attached: {UserWhoAttached}";
        }
        public User UserWhoAttached { get; set; }
        public Place PlaceWhereAttached { get; set; }
    }
}
