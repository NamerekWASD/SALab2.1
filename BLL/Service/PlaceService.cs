using BLL.Controllers;
using BLL.Service.Base;
using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.MatchingToPlace;
using Services.GeneralMappers;
using UoW;

namespace BLL.Service
{
    public class PlaceService : IPlaceService
    {
        private static readonly UnitOfWork UoF = new();
        public PlaceDTO AddPlace(string name, string category, string uniqueName, string location)
        {
            PlaceDTO place = new()
            {
                Name = name,
                Category = category,
                UniqueName = uniqueName,
                Location = location,
            };
            UoF.Places.Create(place.ToModel());
            return place;
        }

        public List<PlaceDTO> GetPlacesByKeyWord(string keyWord)
        {
            var placesFound = from p in UoF.Places.GetAll()
                              .ToList()
                              .ToDTO()
                              where p.Name.Contains(keyWord)
                              select p;

            if (placesFound is null || !placesFound.Any())
            {
                throw new Exception($"Nothing found by keyword {keyWord}.");
            }
            return placesFound.ToList();
        }

        public PlaceDTO EditPlace(PlaceDTO place)
        {
            UoF.Places
                .Update(place.ToModel());

            return place;
        }

        public void DeletePlace(PlaceDTO place)
        {
            UoF.Places
                .Delete(place.ToModel());
        }
        public PlaceDTO AttachFile(PlaceDTO place, UserProfileDTO userWhoAttach, FileContainerDTO file)
        {
            var fileToPlace = new FileContainerDTO()
            {
                Path = file.Path,
                PlaceWhereAttached = place,
                UserWhoAttached = userWhoAttach,
            };

            place.Media.Add(fileToPlace);

            UoF.Places
                .Update(place.ToModel());

            return place;
        }
        public PlaceDTO AddComment(PlaceDTO placeWhereLeft, UserProfileDTO userWhoLeft, string content)
        {
            var comment = new CommentDTO()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft,
                Created = DateTime.Now
            };
            placeWhereLeft.Comments.Add(comment);

            UoF.Places
                .Update(placeWhereLeft.ToModel());

            return placeWhereLeft;
        }
        public PlaceDTO AddReply(PlaceDTO placeWhereLeft, UserProfileDTO userWhoLeft, int onReplyCommentId, string content)
        {
            
            var reply = new CommentDTO()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft,
                Created = DateTime.Now,
                CommentOnRepliedId = onReplyCommentId,
            };
            placeWhereLeft.Comments = InsertReply(
                placeWhereLeft.Comments!,
                onReplyCommentId,
                reply);
               
            UoF.Places.Update(placeWhereLeft.ToModel());

            return placeWhereLeft;
        }

        private List<CommentDTO> InsertReply(List<CommentDTO> comments, int commentToFindId, CommentDTO replyToAdd)
        {
            foreach(var comment in comments)
            {
                if(comment.Replies is not null && comment.Replies.Any())
                {
                    comments = InsertReply(comment.Replies, commentToFindId, replyToAdd);
                }
                if(comment.Id == commentToFindId)
                {
                    comment.Add(replyToAdd);
                    return comments;
                }
            }
            return comments;
        }
    }
}
