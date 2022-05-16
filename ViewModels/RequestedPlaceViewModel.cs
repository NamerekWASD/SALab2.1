using ViewModels.MediaViewModels.Base;

namespace ViewModels
{
    public class RequestedPlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<CommentViewModel>? Comments { get; set; } = new List<CommentViewModel>();
        public virtual List<FileViewModel>? Media { get; set; } = new List<FileViewModel>();
        public override string ToString()
        {
            return $"\n   Name: {Name}" +
                $"\n    Category: {Category}" +
                $"\n    Location: {Country}, {City}";
        }
        public string GetMedia()
        {
            string media = string.Empty;
            if (Media is null || !Media.Any())
            {
                return media;
            }
            foreach (var m in Media)
            {
                media += "\n" + m;
            }
            return media;
        }
        public string GetComments()
        {
            string comments = string.Empty;
            if (Comments is null || !Comments.Any())
            {
                return comments;
            }
            foreach (var c in Comments)
            {
                comments += "\n " + c.ToString();

            }
            return comments;
        }
    }
}
