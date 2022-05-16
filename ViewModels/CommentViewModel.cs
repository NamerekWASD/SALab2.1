namespace ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string UserWhoLeft { get; set; }
        public int PlaceWhereLeftId { get; set; }
        public virtual PlaceViewModel PlaceWhereLeft { get; set; }
        public string Content { get; set; }
        public override string ToString()
        {
            string str = $"{UserWhoLeft}: {Content}";
            str += $"\n{Created.ToString("dddd, dd MMMM yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}";
            return str;
        }
    }
}
