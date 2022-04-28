using Models.PlaceModels;
using Models.UserModels;

namespace Models.CommentModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int UserWhoLeftId { get; set; }
        public virtual UserProfileModel UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceModel PlaceWhereLeft { get; set; }
        public string Content { get; set; }
        public virtual List<CommentModel> Replies { get; set; }
    }
}
