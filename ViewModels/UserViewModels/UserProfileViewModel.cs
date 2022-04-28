using Models.MediaModel.Base;
using ViewModels.CommentViewModels;
using ViewModels.PlaceViewModels;

namespace ViewModels.UserViewModels
{

    public sealed class UserProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Status { get; set; }
        public List<FileBaseViewModel>? FilesAttached { get; set; }
        public List<CommentViewModel>? LeftComments { get; set; }
        public List<PlaceViewModel>? VisitedPlaces { get; set; }
        
        public UserViewModel? AuthentificationData { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
