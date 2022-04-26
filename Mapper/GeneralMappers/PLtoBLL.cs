using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.Base;
using Models.MediaModel.MatchingToPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CommentViewModels;
using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace Mappers.GeneralMappers
{
    public static class PLtoBLL
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
        public static ICollection<PlaceDTO> ToDTO(this ICollection<PlaceViewModel> places)
        {
            ICollection<PlaceDTO> placeDTOs = new List<PlaceDTO>();
            foreach (var place in places)
            {
                placeDTOs.Add(place.ToDTO());
            }
            return placeDTOs;
        }
        public static CommentDTO ToDTO(this CommentViewModel comment)
        {
            return new()
            {
                Id = comment.Id,
                Content = comment.Content,
                Created = comment.Created,
                UserWhoLeft = comment.UserWhoLeft.ToDTO(),
                PlaceWhereLeft = comment.PlaceWhereLeft.ToDTO(),
            };
        }

        public static ICollection<CommentDTO> ToDTO(this ICollection<CommentViewModel> comments)
        {
            ICollection<CommentDTO> commentDTOs = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                commentDTOs.Add(comment.ToDTO());
            }
            return commentDTOs;
        }

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
        public static ICollection<FileContainerDTO> ToDTO(this ICollection<FileBaseViewModel> files)
        {
            ICollection<FileContainerDTO> fileDTOs = new List<FileContainerDTO>();
            foreach (var file in files)
            {
                fileDTOs.Add(file.ToDTO());
            }
            return fileDTOs;
        }
        public static UserDTO ToDTO(this UserViewModel user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                VisitedPlaces = user.VisitedPlaces.ToDTO(),
                LeftComments = user.LeftComments.ToDTO(),
                FilesAttached = user.FilesAttached.ToDTO(),
            };
        }
    }
}
