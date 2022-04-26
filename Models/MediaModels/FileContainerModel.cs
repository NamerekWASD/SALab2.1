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
        public UserModel UserWhoAttached { get; set; }
        public PlaceModel PlaceWhereAttached { get; set; }
    }
}
