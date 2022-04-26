using Models.CommentModels;
using Models.MediaModels;
using Models.PlaceModels;


namespace Models.UserModels
{

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AuthentificationDataId { get; set; }
        public virtual LoginModel AuthentificationData { get; set; }
        public virtual ICollection<FileContainerModel> FilesAttached { get; set; } = new List<FileContainerModel>();
        public virtual ICollection<CommentModel>? LeftComments { get; set; } = new List<CommentModel>();
        public virtual ICollection<PlaceModel>? VisitedPlaces { get; set; } = new List<PlaceModel>();
       
    }
}
