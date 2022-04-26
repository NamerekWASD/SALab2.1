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


        public ICollection<CommentModel>? Comments { get; set; }
        public ICollection<Request>? Requests { get; set; }
        public ICollection<FileContainerModel>? Media { get; set; }
    }

    public class Request
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public PlaceModel PlaceWhereLeft { get; set; }
        public UserModel UserWhoLeft { get; set; }

        public override string ToString()
        {
            return $"  {UserWhoLeft.Name}: {Content}";
        }
    }
}
