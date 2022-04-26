using Models.PlaceModels;
using Models.UserModels;

namespace Models.CommentModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{UserWhoLeft.Name}: {Content}" +
                $"\n Created {Created}";
        }
        public UserModel UserWhoLeft { get; set; }
        public PlaceModel PlaceWhereLeft { get; set; }
    }
}
