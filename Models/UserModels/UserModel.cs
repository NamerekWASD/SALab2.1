using Models.CommentModels;
using Models.MediaModels;
using Models.PlaceModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.UserModels
{

    public sealed class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public LoginModel AuthentificationData { get; set; }
        private int status = 0;
        public int Status { get { return status; } set { status = value; } }
        public ICollection<FileContainerModel> FilesAttached { get; set; } = new List<FileContainerModel>();
        public ICollection<CommentModel>? LeftComments { get; set; } = new List<CommentModel>();
        public ICollection<PlaceModel>? VisitedPlaces { get; set; } = new List<PlaceModel>();
       
    }
}
