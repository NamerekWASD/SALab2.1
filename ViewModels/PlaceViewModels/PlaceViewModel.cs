using Models.MediaModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CommentViewModels;
using ViewModels.UserViewModels;

namespace ViewModels.PlaceViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string UniqueName { get; set; }
        public string Location { get; set; }


        public ICollection<CommentViewModel>? Comments { get; set; } = new List<CommentViewModel>();
        public ICollection<FileBaseViewModel>? Media { get; set; } = new List<FileBaseViewModel>();
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
    }
}
