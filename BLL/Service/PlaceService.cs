using BLL.Controllers;
using BLL.Service.Base;
using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Mappers.GeneralMappers;
using Models.MediaModel.MatchingToPlace;

namespace BLL.Service
{
    public class PlaceService : IPlaceService
    {
        private static readonly PlaceController PlaceController = new();
        public PlaceDTO AddPlace(string name, string category, string uniqueName, string location)
        {
            PlaceDTO place = new()
            {
                Name = name,
                Category = category,
                UniqueName = uniqueName,
                Location = location,
            };
            PlaceController.Create(place.ToModel());
            return place;
        }

        public IEnumerable<PlaceDTO> GetPlacesByKeyWord(string keyWord)
        {
            var placesFound = from p in PlaceController.Index()
                              .ToList()
                              .ToDTO()
                              where p.Name.Contains(keyWord)
                              select p;
            if (placesFound is null || placesFound.Count() == 0)
            {
                throw new Exception($"Nothing found by keyword {keyWord}.");
            }
            return placesFound;
        }

        public PlaceDTO EditPlace(PlaceDTO place)
        {
            PlaceController.Edit(place.ToModel());
            return place;
        }

        public void DeletePlace(PlaceDTO place)
        {
            PlaceController.Delete(place.ToModel());
        }
        public PlaceDTO AttachFile(PlaceDTO place, UserDTO userWhoAttach, FileContainerDTO file)
        {
            var fileToPlace = new FileContainerDTO()
            {
                Path = file.Path,
                PlaceWhereAttached = place,
                UserWhoAttached = userWhoAttach,
            };
            place.Media.Add(fileToPlace);
            userWhoAttach.FilesAttached.Add(fileToPlace);

            PlaceController.Edit(place.ToModel());
            return place;
        }
        public PlaceDTO AddComment(PlaceDTO placeWhereLeft, UserDTO userWhoLeft, string content)
        {
            var comment = new CommentDTO()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft,
                Created = DateTime.Now,
            };
            placeWhereLeft.Comments.Add(comment);

            PlaceController.Edit(placeWhereLeft.ToModel());

            return placeWhereLeft;
        }

    }
}
