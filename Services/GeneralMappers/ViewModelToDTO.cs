using DTO;
using ViewModels;
using ViewModels.MediaViewModels.Base;

namespace Services.GeneralMappers
{
    public static class ViewModelToDTO
    {
        public static PlaceDTO ToDTO(this PlaceViewModel place)
        {
            return new()
            {
                Id = place.Id,
                Name = place.Name,
                Category = place.Category,
                Country = place.Country,
                City = place.City,
                Comments = place.Comments.ToDTO(),
                Media = place.Media.ToDTO(),
            };
        }
        public static List<PlaceDTO> ToDTO(this ICollection<PlaceViewModel> places)
        {
            if (places == null || !places.Any())
                return new();
            List<PlaceDTO> placeDTOs = new();
                foreach (var place in places)
                {
                    placeDTOs.Add(place.ToDTO());
                }
            return placeDTOs;
        }
        public static CommentDTO ToDTO(this CommentViewModel commentVM)
        {
            return new()
            {
                Id = commentVM.Id,
                Content = commentVM.Content,
                Created = commentVM.Created,
                PlaceWhereLeft = commentVM.PlaceWhereLeft.ToDTO(),
                PlaceWhereLeftId = commentVM.PlaceWhereLeftId,
                UserWhoLeft = commentVM.UserWhoLeft
            };
        }
            public static List<CommentDTO> ToDTO(this List<CommentViewModel> comments)
        {
            if (comments == null || !comments.Any())
                return new();
            List<CommentDTO> commentDTOs = new();
            foreach (var comment in comments)
            {
                commentDTOs.Add(comment.ToDTO());
            }
            return commentDTOs;
        }
        public static FileDTO ToDTO(this FileViewModel file)
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
        public static List<FileDTO> ToDTO(this ICollection<FileViewModel> files)
        {
            if (files == null || !files.Any())
                return new();
            List<FileDTO> fileDTOs = new();
                foreach (var file in files)
                {
                    fileDTOs.Add(file.ToDTO());
                }
            return fileDTOs;
        }
        public static RequestStoreDTO ToDTO(this RequestStoreViewModel request)
        {
            return new()
            {
                Id = request.Id,
                Place = request.Place.ToDTO(),
                RequestedPlace = request.RequestedPlace.ToDTO(),
                IsCreated = request.IsCreated,
                IsDeleted = request.IsDeleted,
                IsEdited = request.IsEdited,
                UserWhoAddedRequest = request.UserWhoAddedRequest
            };
        }
        public static List<RequestStoreDTO> ToDTO(this List<RequestStoreViewModel> requests)
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
        public static RequestedPlaceDTO ToDTO(this RequestedPlaceViewModel requested)
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
