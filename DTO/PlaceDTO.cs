namespace DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public List<CommentDTO>? Comments { get; set; }
        public List<FileDTO>? Media { get; set; }
    }
}
