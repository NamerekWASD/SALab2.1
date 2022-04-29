using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.CommentModels;
using Models.MediaModel.MatchingToPlace;
using Models.MediaModels;
using Models.PlaceModels;
using Models.UserModels;
using Services.GeneralMappers;

namespace Services.GeneralMappers
{
    public static class DTOToModel
    {
        public static PlaceModel ToModel(this PlaceDTO placeDTO)
        {
            return new()
            {
                Id = placeDTO.Id,
                Name = placeDTO.Name,
                Category = placeDTO.Category,
                UniqueName = placeDTO.UniqueName,
                Location = placeDTO.Location,
                Comments = placeDTO.Comments.ToModel(),
                Media = placeDTO.Media.ToModel(),
            };
        }
        public static List<PlaceModel> ToModel(this List<PlaceDTO> placeDTOs)
        {
            if (placeDTOs == null || !placeDTOs.Any())
                return new();
            List<PlaceModel> placesModel = new();
                foreach (var place in placeDTOs)
                {
                    placesModel.Add(place.ToModel());
                }
            return placesModel;
        }

        public static FileContainerModel ToModel(this FileContainerDTO FileDTO)
        {
            return new()
            {
                Id = FileDTO.Id,
                Path = FileDTO.Path,
                UserWhoAttached = FileDTO.UserWhoAttached.ToModel(),
                PlaceWhereAttached = FileDTO.PlaceWhereAttached.ToModel(),
            };
        }
        public static List<FileContainerModel> ToModel(this ICollection<FileContainerDTO> filesDTO)
        {
            if (filesDTO == null || !filesDTO.Any())
                return new();
            List<FileContainerModel> filesModel = new();
            foreach (var file in filesDTO)
            {
                filesModel.Add(file.ToModel());
            }
            return filesModel;
        }
        public static UserProfileModel ToModel(this UserProfileDTO userDTO)
        {
            return new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                VisitedPlaces = userDTO.VisitedPlaces.ToModel(),
                LeftComments = userDTO.LeftComments.ToModel(),
                FilesAttached = userDTO.FilesAttached.ToModel(),
            };
        }
        public static UserModel ToModel(this UserDTO data)
        {
            return new()
            {
                Id = data.Id,
                Email = data.Email,
                Password = data.Password,
                Status = data.Status,
                UserProfile = data.UserProfile.ToModel(),
            };
        }

        public static CommentModel ToModel(this CommentDTO commentDTO)
        {
            return new()
            {
                Id = commentDTO.Id,
                Content = commentDTO.Content,
                Created = commentDTO.Created,
                UserWhoLeft = commentDTO.UserWhoLeft.ToModel(),
                UserWhoLeftId = commentDTO.UserWhoLeftId,
                PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToModel(),
                PlaceWhereLeftId = commentDTO.PlaceWhereLeftId,
                
            };
        }

        public static List<CommentModel> ToModel(this List<CommentDTO> commentsDTO)
        {
            if (commentsDTO == null || !commentsDTO.Any())
                return new();
            List<CommentModel> commentsModel = new();
            foreach (var comment in commentsDTO)
            {
                commentsModel.Add(comment.ToModel());
            }
            return commentsModel;
        }
    }
}
