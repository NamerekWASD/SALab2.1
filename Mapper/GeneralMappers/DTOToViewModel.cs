using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.Base;
using Models.MediaModel.MatchingToPlace;
using Services.GeneralMappers;
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
        public static List<PlaceViewModel> ToViewModel(this List<PlaceDTO> placesDTO)
        {
            List<PlaceViewModel> placesViewModel = new();
            if (placesDTO != null && placesDTO.Count != 0)
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
        public static List<CommentViewModel> ToViewModel(this List<CommentDTO> commentsDTO)
        {
            List<CommentViewModel> commentsViewModel = new ();
            if (commentsDTO != null && commentsDTO.Count != 0)
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
        public static List<FileBaseViewModel> ToViewModel(this List<FileContainerDTO> filesDTO)
        {
            List<FileBaseViewModel> filesModel = new List<FileBaseViewModel>();
            if (filesDTO != null && filesDTO.Count != 0)
                foreach (var file in filesDTO)
                {
                    filesModel.Add(file.ToViewModel());
                }
            return filesModel;
        }
        public static UserProfileViewModel ToViewModel(this UserProfileDTO userDTO)
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
