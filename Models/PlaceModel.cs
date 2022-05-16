

namespace Models
{
    public class PlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<CommentModel>? Comments { get; set; }
        public virtual List<FileModel>? Media { get; set; }
    }
}
