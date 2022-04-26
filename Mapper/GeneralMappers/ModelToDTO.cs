using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.CommentModels;
using Models.MediaModel.MatchingToPlace;
using Models.MediaModels;
using Models.PlaceModels;
using Models.UserModels;

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
        public static ICollection<PlaceDTO> ToDTO(this ICollection<PlaceModel> places)
        {
            ICollection<PlaceDTO> placeDTOs = new List<PlaceDTO>();
            if (places != null)
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
            };
        }

        public static ICollection<CommentDTO> ToDTO(this ICollection<CommentModel> comments)
        {
            ICollection<CommentDTO> commentDTOs = new List<CommentDTO>();
            if (comments != null)
                foreach (var comment in comments)
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
        public static ICollection<FileContainerDTO> ToDTO(this ICollection<FileContainerModel> files)
        {
            ICollection<FileContainerDTO> fileDTOs = new List<FileContainerDTO>();
            if (files != null)
                foreach (var file in files)
                {
                    fileDTOs.Add(file.ToDTO());
                }
            return fileDTOs;
        }
        public static UserDTO ToDTO(this UserModel user)
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
