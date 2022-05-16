namespace DTO
{
    public class RequestedPlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<CommentDTO>? Comments { get; set; } = new List<CommentDTO>();
        public virtual List<FileDTO>? Media { get; set; } = new List<FileDTO>();
    }
}
