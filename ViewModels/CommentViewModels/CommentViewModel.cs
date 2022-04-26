using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{UserWhoLeft.Name}: {Content}" +
                $"\n Created {Created}";
        }
        public UserViewModel UserWhoLeft { get; set; }
        public PlaceViewModel PlaceWhereLeft { get; set; }
    }
}
