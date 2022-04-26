using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.Base;
using Models.MediaModel.MatchingToPlace;
using ViewModels.CommentViewModels;
using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace Mappers.GeneralMappers
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
                UniqueName = placeDTO.UniqueName,
                Location = placeDTO.Location,
                Comments = placeDTO.Comments.ToViewModel(),
                Media = placeDTO.Media.ToViewModel(),
            };
        }
        public static ICollection<PlaceViewModel> ToViewModel(this ICollection<PlaceDTO> placesDTO)
        {
            ICollection<PlaceViewModel> placesViewModel = new List<PlaceViewModel>();
            if (placesDTO != null)
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
                UserWhoLeft = commentDTO.UserWhoLeft.ToViewModel(),
                PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToViewModel(),
            };
        }
        public static ICollection<CommentViewModel> ToViewModel(this ICollection<CommentDTO> commentsDTO)
        {
            ICollection<CommentViewModel> commentsViewModel = new List<CommentViewModel>();
            if (commentsDTO != null)
                foreach (var comment in commentsDTO)
                {
                    commentsViewModel.Add(comment.ToViewModel());
                }
            return commentsViewModel;
        }

        public static FileBaseViewModel ToViewModel(this FileContainerDTO FileDTO)
        {
            return new()
            {
                Id = FileDTO.Id,
                Path = FileDTO.Path,
                UserWhoAttached = FileDTO.UserWhoAttached.ToViewModel(),
                PlaceWhereAttached = FileDTO.PlaceWhereAttached.ToViewModel(),
            };
        }
        public static ICollection<FileBaseViewModel> ToViewModel(this ICollection<FileContainerDTO> filesDTO)
        {
            ICollection<FileBaseViewModel> filesModel = new List<FileBaseViewModel>();
            if (filesDTO != null)
                foreach (var file in filesDTO)
                {
                    filesModel.Add(file.ToViewModel());
                }
            return filesModel;
        }
        public static UserViewModel ToViewModel(this UserDTO userDTO)
        {
            return new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                VisitedPlaces = userDTO.VisitedPlaces.ToViewModel(),
                LeftComments = userDTO.LeftComments.ToViewModel(),
                FilesAttached = userDTO.FilesAttached.ToViewModel(),
            };
        }
    }
}
