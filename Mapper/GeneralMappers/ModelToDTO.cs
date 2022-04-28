using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.CommentModels;
using Models.MediaModel.MatchingToPlace;
using Models.MediaModels;
using Models.PlaceModels;
using Models.UserModels;
using Services.CommentService;
using Services.GeneralMappers;

namespace Mappers.GeneralMappers
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
            List<PlaceDTO> placeDTOs = new();
            if (places != null && places.Count != 0)
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
                UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                Replies = comment.Replies.ToDTO(),
            };
        }
        public static CommentDTO ToDTO(this CommentBaseModel comment)
        {
            return new()
            {
                Id = comment.Id,
                Content = comment.Content,
                Created = comment.Created,
                UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
            };
        }

        public static List<CommentBaseDTO> ToDTO(this List<CommentModel> comments)
        {
            List<CommentBaseDTO> commentDTOs = new();
            if (comments != null && comments.Count != 0)
                foreach (var comment in comments.ToBaseList())
                {
                    commentDTOs.Add(comment.ToDTO());
                }
            return commentDTOs;
        }

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
            List<FileContainerDTO> fileDTOs = new();
            if (files != null && files.Count != 0)
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
