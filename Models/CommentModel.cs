namespace Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceModel PlaceWhereLeft { get; set; }
        public string Content { get; set; }
    }
}
