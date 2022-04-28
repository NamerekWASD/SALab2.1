using Models.CommentModels;
using Models.MediaModels;
using Models.PlaceModels;


namespace Models.UserModels
{

    public class UserProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status => UserData.Status;
        public virtual UserModel UserData { get; set; }
        public virtual List<FileContainerModel> FilesAttached { get; set; }
        public virtual List<CommentModel>? LeftComments { get; set; }
        public virtual List<PlaceModel>? VisitedPlaces { get; set; }
       
    }
}
