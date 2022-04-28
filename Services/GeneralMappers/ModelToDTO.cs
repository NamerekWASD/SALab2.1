using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.CommentModels;
using Models.MediaModel.MatchingToPlace;
using Models.MediaModels;
using Models.PlaceModels;
using Models.UserModels;

namespace Services.GeneralMappers
{
    public static class ModelToDTO
    {
        public static PlaceDTO ToDTO(this PlaceModel place)
        {
            return new()
            {
                Id = place.Id,
                Name = place.Name,
                Category = place.Category,
                UniqueName = place.UniqueName,
                Location = place.Location,
                Comments = place.Comments.ToDTO(),
                Media = place.Media.ToDTO(),
            };
        }
        public static List<PlaceDTO> ToDTO(this ICollection<PlaceModel> places)
        {
            if (places == null || places.Count == 0)
                return new();
            List<PlaceDTO> placeDTOs = new();
            foreach (var place in places)
            {
                placeDTOs.Add(place.ToDTO());
            }
            return placeDTOs;
        }
        public static CommentDTO ToDTO(this CommentModel comment)
        {

            return new()
            {
                Id = comment.Id,
                Content = comment.Content,
                Created = comment.Created,
                PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                PlaceWhereLeftId = comment.PlaceWhereLeftId,
                UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                UserWhoLeftId = comment.UserWhoLeftId,
            };
        }
        public static List<CommentDTO> ToDTO(this List<CommentModel> comments)
        {
            if (comments == null || comments.Count == 0)
                return new();
            List<CommentDTO> commentsbase = new();
            foreach (var comment in comments)
            {
                commentsbase.Add(comment.ToDTO());
            }
            return commentsbase;
        }
        /*public static CommentBaseDTO ToDTO(this CommentModel comment)
        {
            if (comment.Replies == null && comment.Replies.Count == 0)
            {
                return new ReplyDTO()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                    UserWhoLeftId = comment.UserWhoLeftId,
                };
            }
            else
            {
                return new CommentDTO()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                    UserWhoLeftId = comment.UserWhoLeftId,
                    Replies = comment.Replies.ToDTO(),
                };
            }
        }
        public static List<CommentBaseDTO> ToDTO(this List<CommentModel> comments)
        {
            List<CommentBaseDTO> commentsbase = new();
            if (comments == null || comments.Count == 0)
                commentsbase.AddRange(from comment in comments
                                      select comment.ToDTO());
            return commentsbase;
        }*/
        public static FileContainerDTO ToDTO(this FileContainerModel file)
        {
            return new()
            {
                Id = file.Id,
                Path = file.Path,
                UserWhoAttached = file.UserWhoAttached.ToDTO(),
                PlaceWhereAttached = file.PlaceWhereAttached.ToDTO(),
            };
        }
        public static List<FileContainerDTO> ToDTO(this List<FileContainerModel> files)
        {
            if (files == null || files.Count == 0)
                return new();
            List<FileContainerDTO> fileDTOs = new();
            foreach (var file in files)
            {
                fileDTOs.Add(file.ToDTO());
            }
            return fileDTOs;
        }
        public static UserProfileDTO ToDTO(this UserProfileModel user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Status = user.Status,
                VisitedPlaces = user.VisitedPlaces.ToDTO(),
                LeftComments = user.LeftComments.ToDTO(),
                FilesAttached = user.FilesAttached.ToDTO(),
            };
        }
    }
}
