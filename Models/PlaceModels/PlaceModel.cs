using Models.CommentModels;
using Models.MediaModels;
using Models.UserModels;

namespace Models.PlaceModels
{
    public class PlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string UniqueName { get; set; }
        public string Location { get; set; }


        public virtual ICollection<CommentModel>? Comments { get; set; }
        public virtual ICollection<FileContainerModel>? Media { get; set; }
    }
}
