using DAL.Entities.CommentEntity;
using DAL.Entities.MediaEntity.MatchingToPlace;
using DAL.Entities.PersonEntity;

namespace DAL.Entities.PlaceEntity
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
            string questions = string.Empty;
            if (Questions is null || Questions.Count is 0)
            {
                return questions;
            }
            foreach (var q in Questions)
            {
                questions += "\n" + q;
            }
            return questions;
        }

        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public ICollection<Question>? Questions { get; set; } = new List<Question>();
        public ICollection<FileAdapter>? Media { get; set; } = new List<FileAdapter>();
    }

    public class Question
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
