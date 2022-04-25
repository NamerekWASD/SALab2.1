using DAL.Models.CommentEntity;
using DAL.Models.MediaEntity.MatchingToPlace;
using DAL.Models.PersonEntity;

namespace DAL.Models.PlaceEntity
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string UniqueName { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}" +
                $"\nCategory: {Category}" +
                $"\nLocation: {Location}" +
                $"\nUnique name: {UniqueName}";
        }
        public string GetMedia()
        {
            string media = string.Empty;
            if (Media is null || Media.Count is 0)
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
            if (Comments is null || Comments.Count is 0)
            {
                return comments;
            }
            foreach (var c in Comments)
            {
                comments += "\n " + c;
            }
            return comments;
        }
        public string GetQuestions()
        {
            string requests = string.Empty;
            if (Requests is null || Requests.Count is 0)
            {
                return requests;
            }
            foreach (var q in Requests)
            {
                requests += "\n" + q;
            }
            return requests;
        }

        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public ICollection<Request>? Requests { get; set; } = new List<Request>();
        public ICollection<FileContainer>? Media { get; set; } = new List<FileContainer>();
    }

    public class Request
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Place PlaceWhereLeft { get; set; }
        public User UserWhoLeft { get; set; }

        public override string ToString()
        {
            return $"  {UserWhoLeft.Name}: {Content}";
        }
    }
}
