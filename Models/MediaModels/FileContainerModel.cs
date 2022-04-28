using Models.PlaceModels;
using Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.MediaModels
{
    public class FileContainerModel
    {
        public int Id { get; set; }
        private string _path;
        public string Path { get { return _path; } set { _path = value; } }
        public int UserWhoAttachedId { get; set; }
        public virtual UserProfileModel UserWhoAttached { get; set; }
        public int PlaceWhereAttachedId { get; set; }
        public virtual PlaceModel PlaceWhereAttached { get; set; }
    }
}
