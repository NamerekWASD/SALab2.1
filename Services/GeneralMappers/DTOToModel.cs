using DTO;
using Models;
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
                Comments = placeDTO.Comments.ToModel(),
                Media = placeDTO.Media.ToModel(),
                Country = placeDTO.Country,
                City = placeDTO.City,
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

        public static FileModel ToModel(this FileDTO FileDTO)
        {
            return new()
            {
                Id = FileDTO.Id,
                Name = FileDTO.Name,
                Path = FileDTO.Path,
                UserWhoAttached = FileDTO.UserWhoAttached,
                PlaceWhereAttached = FileDTO.PlaceWhereAttached.ToModel(),
            };
        }
        public static List<FileModel> ToModel(this ICollection<FileDTO> filesDTO)
        {
            if (filesDTO == null || !filesDTO.Any())
                return new();
            List<FileModel> filesModel = new();
            foreach (var file in filesDTO)
            {
                filesModel.Add(file.ToModel());
            }
            return filesModel;
        }

        public static CommentModel ToModel(this CommentDTO commentDTO)
        {
            return new()
            {
                Id = commentDTO.Id,
                Content = commentDTO.Content,
                Created = commentDTO.Created,
                UserWhoLeft = commentDTO.UserWhoLeft,
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
        public static RequestStoreModel ToModel(this RequestStoreDTO request)
        {
            return new()
            {
                Id = request.Id,
                Place = request.Place.ToModel(),
                RequestedPlace = request.RequestedPlace.ToModel(),
                IsCreated = request.IsCreated,
                IsDeleted = request.IsDeleted,
                IsEdited = request.IsEdited,
                UserWhoAddedRequest = request.UserWhoAddedRequest
            };
        }
        public static List<RequestStoreModel> ToModel(this List<RequestStoreDTO> requests)
        {
            if (requests == null || requests.Count == 0)
                return new();
            List<RequestStoreModel> requestModel = new();
            foreach (var request in requests)
            {
                requestModel.Add(request.ToModel());
            }
            return requestModel;
        }
        public static RequestedPlace ToModel(this RequestedPlaceDTO requested)
        {
            return new()
            {
                Id = requested.Id,
                Name = requested.Name,
                Category = requested.Category,
                Country = requested.Country,
                City = requested.City,
                Comments = requested.Comments.ToModel(),
                Media = requested.Media.ToModel(),
            };
        }
    }
}
