using Models.MediaModel.Base;
using ViewModels.CommentViewModels;
using ViewModels.PlaceViewModels;

namespace ViewModels.UserViewModels
{

    public sealed class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public int status = 0;
        public int Status { get; }
        public ICollection<FileBaseViewModel> FilesAttached { get; set; } = new List<FileBaseViewModel>();
        public ICollection<CommentViewModel>? LeftComments { get; set; } = new List<CommentViewModel>();
        public ICollection<PlaceViewModel>? VisitedPlaces { get; set; } = new List<PlaceViewModel>();
        
        public LoginViewModel AuthentificationData { get; set; }

        public override string ToString()
        {
            return $"Profile:\n" +
                $"  Name: {Name}\n" +
                $"  Surname: {Surname}" +
                $"";
        }
    }
}
