using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.MediaViewModels.Base;

namespace ViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


        public List<CommentViewModel>? Comments { get; set; }
        public List<FileViewModel>? Media { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}" +
                $"\nCategory: {Category}" +
                $"\nLocation: {Country}, {City}";
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
