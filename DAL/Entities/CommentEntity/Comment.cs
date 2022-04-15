using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;

namespace DAL.Entities.CommentEntity
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
