using Models.PlaceModels;
using Models.UserModels;

namespace Models.CommentModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int UserWhoLeftId { get; set; }
        public virtual UserModel UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceModel PlaceWhereLeft { get; set; }
    }
}
