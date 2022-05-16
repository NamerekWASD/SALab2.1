namespace DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public PlaceDTO PlaceWhereLeft { get; set; }
        public string Content { get; set; }
    }
}
