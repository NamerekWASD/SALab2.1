using DTO;
using Models;

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
                Country = place.Country,
                City = place.City,
                Comments = place.Comments!.ToDTO(),
                Media = place.Media!.ToDTO(),
            };
        }
        public static List<PlaceDTO> ToDTO(this List<PlaceModel> places)
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
                UserWhoLeft = comment.UserWhoLeft
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
        public static FileDTO ToDTO(this FileModel file)
        {
            return new()
            {
                Id = file.Id,
                Name = file.Name,
                Path = file.Path,
                UserWhoAttached = file.UserWhoAttached,
                PlaceWhereAttached = file.PlaceWhereAttached.ToDTO(),
            };
        }
        public static List<FileDTO> ToDTO(this List<FileModel> files)
        {
            if (files == null || files.Count == 0)
                return new();
            List<FileDTO> fileDTOs = new();
            foreach (var file in files)
            {
                fileDTOs.Add(file.ToDTO());
            }
            return fileDTOs;
        }
        public static RequestStoreDTO ToDTO(this RequestStoreModel request)
        {
            return new()
            {
                Id = request.Id,
                Place = request.Place?.ToDTO(),
                RequestedPlace = request.RequestedPlace?.ToDTO(),
                IsCreated = request.IsCreated,
                IsDeleted = request.IsDeleted,
                IsEdited = request.IsEdited,
                UserWhoAddedRequest = request.UserWhoAddedRequest
            };
        }
        public static List<RequestStoreDTO> ToDTO(this List<RequestStoreModel> requests)
        {
            if (requests == null || requests.Count == 0)
                return new();
            List<RequestStoreDTO> requestsDTO = new();
            foreach (var request in requests)
            {
                requestsDTO.Add(request.ToDTO());
            }
            return requestsDTO;
        }
        public static RequestedPlaceDTO ToDTO(this RequestedPlace requested)
        {
            return new()
            {
                Id = requested.Id,
                Name = requested.Name,
                Category = requested.Category,
                Country = requested.Country,
                City = requested.City,
                Comments = requested.Comments.ToDTO(),
                Media = requested.Media.ToDTO(),
            };
        }
    }
}
