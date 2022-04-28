using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.Base;
using Models.MediaModel.MatchingToPlace;
using Services.GeneralMappers;
using ViewModels.CommentViewModels;
using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

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
                UniqueName = placeDTO.UniqueName,
                Location = placeDTO.Location,
                Comments = placeDTO.Comments.ToViewModel(),
                Media = placeDTO.Media.ToViewModel(),
            };
        }
        public static List<PlaceViewModel> ToViewModel(this ICollection<PlaceDTO> placesDTO)
        {
            if (placesDTO == null || placesDTO.Count == 0)
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
                UserWhoLeft = commentDTO.UserWhoLeft.ToViewModel(),
                UserWhoLeftId = commentDTO.UserWhoLeftId,
                Replies = commentDTO.Replies.ToViewModel(),
            };
        }
        public static List<CommentViewModel> ToViewModel(this List<CommentDTO> commentsDTO)
        {
            if (commentsDTO == null || commentsDTO.Count == 0)
                return new();
            List<CommentViewModel> commentsViewModel = new();
            foreach (var comment in commentsDTO)
            {
                commentsViewModel.Add(comment.ToViewModel());
            }
            return commentsViewModel;
        }
        /*public static CommentBaseViewModel ToViewModel(this CommentBaseDTO comment)
        {
            var commentDTO = comment as CommentDTO;
            if (commentDTO.Replies == null && commentDTO.Replies.Count == 0)
            {
                return new ReplyViewModel()
                {
                    Id = commentDTO.Id,
                    Content = commentDTO.Content,
                    Created = commentDTO.Created,
                    PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToViewModel(),
                    PlaceWhereLeftId = commentDTO.PlaceWhereLeftId,
                    UserWhoLeft = commentDTO.UserWhoLeft.ToViewModel(),
                    UserWhoLeftId = commentDTO.UserWhoLeftId,
                };
            }
            else
            {
                return new CommentViewModel()
                {
                    Id = commentDTO.Id,
                    Content = commentDTO.Content,
                    Created = commentDTO.Created,
                    PlaceWhereLeft = commentDTO.PlaceWhereLeft.ToViewModel(),
                    PlaceWhereLeftId = commentDTO.PlaceWhereLeftId,
                    UserWhoLeft = commentDTO.UserWhoLeft.ToViewModel(),
                    UserWhoLeftId = commentDTO.UserWhoLeftId,
                    Replies = commentDTO.Replies.ToViewModel(),
                };
            }
        }
        public static List<CommentBaseViewModel> ToViewModel(this List<CommentBaseDTO> commentsDTO)
        {
            List<CommentBaseViewModel> commentsViewModel = new ();
            if (commentsDTO != null && commentsDTO.Count != 0)
                foreach (var comment in commentsDTO)
                {
                    commentsViewModel.Add(comment.ToViewModel());
                }
            return commentsViewModel;
        }*/

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
        public static List<FileBaseViewModel> ToViewModel(this ICollection<FileContainerDTO> filesDTO)
        {
            if (filesDTO == null || filesDTO.Count == 0)
                return new();
            List <FileBaseViewModel> filesModel = new();
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
                Status = userDTO.Status,
                VisitedPlaces = userDTO.VisitedPlaces.ToViewModel(),
                LeftComments = userDTO.LeftComments.ToViewModel(),
                FilesAttached = userDTO.FilesAttached.ToViewModel(),
            };
        }
    }
}
