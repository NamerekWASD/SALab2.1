using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public virtual List<CommentViewModel>? Replies { get; set; }
        public int Id { get; set; }
        public int CommentOnRepliedId { get; set; }
        public DateTime Created { get; set; }
        public int UserWhoLeftId { get; set; }
        public virtual UserProfileViewModel UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceViewModel PlaceWhereLeft { get; set; }
        public string Content { get; set; }
        public string ToString(int padint = 0)
        {
            string str = $"{UserWhoLeft}: {Content}";
            str = str.PadLeft(
                str.Length + padint
                );
            str += $"\n{Created.ToString("dddd, dd MMMM yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}"
                .PadRight(
                str.Length + padint
                );

            if (Replies is not null && Replies.Count is not 0)
                foreach (var r in Replies)
                {
                    str += r.ToString(padint + 1);
                }
            return str;
        }
    }
}
