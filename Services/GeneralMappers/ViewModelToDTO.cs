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
    public static class ViewModelToDTO
    {
        public static PlaceDTO ToDTO(this PlaceViewModel place)
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
                UserWhoLeft = commentVM.UserWhoLeft.ToDTO(),
                UserWhoLeftId = commentVM.UserWhoLeftId,
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
        /*public static CommentBaseDTO ToDTO(this CommentBaseViewModel commentVM)
        {
            var comment = commentVM as CommentViewModel;
            if (comment.Replies == null && comment.Replies.Count == 0)
            {
                return new ReplyDTO()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CommentOnRepliedId = comment.CommentOnRepliedId,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                    UserWhoLeftId = comment.UserWhoLeftId,
                };
            }
            else
            {
                return new CommentDTO()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Created = comment.Created,
                    PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
                    PlaceWhereLeftId = comment.PlaceWhereLeftId,
                    UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                    UserWhoLeftId = comment.UserWhoLeftId,
                    Replies = comment.Replies.ToDTO(),
                };
            }
        }

        public static List<CommentBaseDTO> ToDTO(this List<ReplyBaseViewModel> comments)
        {
            List<ReplyDTO> commentDTOs = new();
            if (comments != null && comments.Count != 0)
                foreach (var comment in comments)
                {
                    commentDTOs.Add(comment.ToDTO());
                }
            return commentDTOs;
        }*/

        public static FileContainerDTO ToDTO(this FileBaseViewModel file)
        {
            return new()
            {
                Id = file.Id,
                Path = file.Path,
                UserWhoAttached = file.UserWhoAttached.ToDTO(),
                PlaceWhereAttached = file.PlaceWhereAttached.ToDTO(),
            };
        }
        public static List<FileContainerDTO> ToDTO(this ICollection<FileBaseViewModel> files)
        {
            if (files == null || !files.Any())
                return new();
            List<FileContainerDTO> fileDTOs = new();
                foreach (var file in files)
                {
                    fileDTOs.Add(file.ToDTO());
                }
            return fileDTOs;
        }
        public static UserProfileDTO ToDTO(this UserProfileViewModel user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                VisitedPlaces = user.VisitedPlaces.ToDTO(),
                LeftComments = user.LeftComments.ToDTO(),
                FilesAttached = user.FilesAttached.ToDTO(),
                UserData = user.AuthentificationData.ToDTO()
            };
        }
        public static UserDTO ToDTO(this UserViewModel data)
        {
            return new()
            {
                Id = data.Id,
                Email = data.Email,
                Password = data.Password,
                UserId = data.UserId
            };
        }
    }
}
