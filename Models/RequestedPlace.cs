namespace Models
{
    public class RequestedPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<CommentModel>? Comments { get; set; } = new List<CommentModel>();
        public virtual List<FileModel>? Media { get; set; } = new List<FileModel>();
    }
}
