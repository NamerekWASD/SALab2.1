using DTO;
using ViewModels;
using ViewModels.MediaViewModels.Base;

namespace Services.GeneralMappers
{
    public static class DTOToViewModel
    {
        public static PlaceViewModel ToViewModel(this PlaceDTO placeDTO)
        {
            return new()
            {
                Id = placeDTO.Id,
                Name = placeDTO.Name,
                Category = placeDTO.Category,
                Comments = placeDTO.Comments.ToViewModel(),
                Media = placeDTO.Media.ToViewModel(),
                Country = placeDTO.Country,
                City = placeDTO.City,
            };
        }
        public static List<PlaceViewModel> ToViewModel(this ICollection<PlaceDTO> placesDTO)
        {
            if (placesDTO == null || !placesDTO.Any())
                return new();
            List<PlaceViewModel> placesViewModel = new();
            foreach (var place in placesDTO)
            {
                placesViewModel.Add(place.ToViewModel());
            }
            return placesViewModel;
        }
        public static CommentViewModel ToViewModel(this CommentDTO commentDTO)
        {
            return new()
            {
                Id = commentDTO.Id,
                Content = commentDTO.Content,
                Created = commentDTO.Created,
                PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToViewModel(),
                PlaceWhereLeftId = commentDTO.PlaceWhereLeftId,
                UserWhoLeft = commentDTO.UserWhoLeft
            };
        }
        public static List<CommentViewModel> ToViewModel(this List<CommentDTO> commentsDTO)
        {
            if (commentsDTO == null || !commentsDTO.Any())
                return new();
            List<CommentViewModel> commentsViewModel = new();
            foreach (var comment in commentsDTO)
            {
                commentsViewModel.Add(comment.ToViewModel());
            }
            return commentsViewModel;
        }
        public static FileViewModel ToViewModel(this FileDTO FileDTO)
        {
            return new()
            {
                Id = FileDTO.Id,
                Name = FileDTO.Name,
                Path = FileDTO.Path,
                UserWhoAttached = FileDTO.UserWhoAttached,
                PlaceWhereAttached = FileDTO.PlaceWhereAttached.ToViewModel(),
            };
        }
        public static List<FileViewModel> ToViewModel(this ICollection<FileDTO> filesDTO)
        {
            if (filesDTO == null || !filesDTO.Any())
                return new();
            List <FileViewModel> filesModel = new();
            foreach (var file in filesDTO)
            {
                filesModel.Add(file.ToViewModel());
            }
            return filesModel;
        }
        public static RequestStoreViewModel ToViewModel(this RequestStoreDTO request)
        {
            return new()
            {
                Id = request.Id,
                Place = request.Place.ToViewModel(),
                RequestedPlace = request.RequestedPlace.ToViewModel(),
                IsCreated = request.IsCreated,
                IsDeleted = request.IsDeleted,
                IsEdited = request.IsEdited,
                UserWhoAddedRequest = request.UserWhoAddedRequest
            };
        }
        public static List<RequestStoreViewModel> ToViewModel(this List<RequestStoreDTO> requests)
        {
            if (requests == null || requests.Count == 0)
                return new();
            List<RequestStoreViewModel> requestVM = new();
            foreach (var request in requests)
            {
                requestVM.Add(request.ToViewModel());
            }
            return requestVM;
        }
        public static RequestedPlaceViewModel ToViewModel(this RequestedPlaceDTO requested)
        {
            return new()
            {
                Id = requested.Id,
                Name = requested.Name,
                Category = requested.Category,
                Country = requested.Country,
                City = requested.City,
                Comments = requested.Comments.ToViewModel(),
                Media = requested.Media.ToViewModel(),
            };
        }
    }
}
