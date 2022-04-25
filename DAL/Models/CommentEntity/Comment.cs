using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;

namespace DAL.Models.CommentEntity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{UserWhoLeft.Name}: {Content}" +
                $"\n Created {Created}";
        }
        public User UserWhoLeft { get; set; }
        public Place PlaceWhereLeft { get; set; }
    }
}
