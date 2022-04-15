using DAL.Entities.MediaEntity.Base;
using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.MediaEntity.MatchingToPlace
{
    public class FileAdapter
    {
        public int Id { get; set; }
        private string _path;
        [NotMapped]
        public FileBase File { private get; set; }
        public string Path 
        {
            set
            {
                _path = value;
            }
            get
            {
                return _path;
            }
        }
        public override string ToString()
        {
            return File.ToString() 
                + $"\n  Person who attached: {UserWhoAttached}";
        }
        public User UserWhoAttached { get; set; }
        public Place PlaceWhereAttached { get; set; }
    }
}
