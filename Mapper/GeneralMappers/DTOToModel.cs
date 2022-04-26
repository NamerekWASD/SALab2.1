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
        public static ICollection<PlaceModel> ToModel(this ICollection<PlaceDTO> placeDTOs)
        {
            ICollection<PlaceModel> placesModel = new List<PlaceModel>();
            if (placeDTOs != null)
                foreach (var place in placeDTOs)
                {
                    placesModel.Add(place.ToModel());
                }
            return placesModel;
        }
        public static CommentModel ToModel(this CommentDTO commentDTO)
        {
            return new()
            {
                Id = commentDTO.Id,
                Content = commentDTO.Content,
                Created = commentDTO.Created,
                UserWhoLeft = commentDTO.UserWhoLeft.ToModel(),
                PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToModel(),
            };
        }

        public static ICollection<CommentModel> ToModel(this ICollection<CommentDTO> commentsDTO)
        {
            ICollection<CommentModel> commentsModel = new List<CommentModel>();
            if (commentsDTO != null)
                foreach (var comment in commentsDTO)
                {
                    commentsModel.Add(comment.ToModel());
                }
            return commentsModel;
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
        public static ICollection<FileContainerModel> ToModel(this ICollection<FileContainerDTO> filesDTO)
        {
            ICollection<FileContainerModel> filesModel = new List<FileContainerModel>();
            if (filesDTO != null)
                foreach (var file in filesDTO)
                {
                    filesModel.Add(file.ToModel());
                }
            return filesModel;
        }
        public static UserModel ToModel(this UserDTO userDTO)
        {
            return new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                VisitedPlaces = userDTO.VisitedPlaces.ToModel(),
                LeftComments = userDTO.LeftComments.ToModel(),
                FilesAttached = userDTO.FilesAttached.ToModel(),
                AuthentificationData = userDTO.AuthentificationData.ToModel()
            };
        }
        public static LoginModel ToModel(this LoginDTO data)
        {
            return new()
            {
                Id = data.Id,
                Email = data.Email,
                Password = data.Password,
                UserId = data.UserId,
            };
        }
    }
}
