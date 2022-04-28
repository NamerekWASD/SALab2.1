using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommentService
{
    public static class ExtensionMethods
    {
        public static CommentBaseModel ToBase(this CommentModel comment)
        {
            if (comment.Replies == null && comment.Replies.Count == 0)
            {
                return new CommentLeafModel()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CommentOnRepliedId = comment.CommentOnRepliedId,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft,
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft,
                    UserWhoLeftId = comment.UserWhoLeftId,
                };
            }
            else
            {
                return new CommentModel()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CommentOnRepliedId = comment.CommentOnRepliedId,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft,
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft,
                    UserWhoLeftId = comment.UserWhoLeftId,
                    Replies = comment.Replies.ToBaseList(),
                };
            }
        }
        public static List<CommentBaseModel> ToBaseList(this List<CommentModel> comments)
        {
            if (comments == null && comments.Count == 0)
            {
                return new();
            }
            List<CommentBaseModel> commentsbase = new();
            foreach (var comment in comments)
            {
                var commentToList = comment.ToBase();
                if (commentToList.IsComposite())
                {
                    commentsbase.Add(comment);
                }
                else
                {
                    commentsbase.Add(comment.ToBase());
                }
            }
            return commentsbase;
        }
        public static CommentModel ToModel(this CommentBaseModel comment)
        {
            return new()
            {
                Id = comment.Id,
                Content = comment.Content,
                CommentOnRepliedId = comment.CommentOnRepliedId,
                Created = comment.Created,
                PlaceWhereLeft = comment.PlaceWhereLeft,
                PlaceWhereLeftId = comment.PlaceWhereLeftId,
                UserWhoLeft = comment.UserWhoLeft,
                UserWhoLeftId = comment.UserWhoLeftId,
            };
        }
    }
}
