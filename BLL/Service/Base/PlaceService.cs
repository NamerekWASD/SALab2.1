using DAL.Controllers;
using DAL.Models.CommentEntity;
using DAL.Models.MediaEntity.Base;
using DAL.Models.MediaEntity.MatchingToPlace;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;

namespace SALab2._1.Service.Base
{
    public class PlaceService : IPlaceService
    {
        private static readonly PlaceController PlaceController = new();
        public Place AddPlace(string name, string category, string uniqueName, string location)
        {
            Place place = new()
            {
                Name = name,
                Category = category,
                UniqueName = uniqueName,
                Location = location,
            };
            PlaceController.Create(place);
            return place;
        }

        public List<Place> GetPlacesByKeyWord(string keyWord)
        {
            var placesFound = from p in PlaceController.Index()
                              where p.Name.Contains(keyWord)
                              select p;
            if (placesFound is null || placesFound.Count() == 0)
            {
                throw new Exception($"Nothing found by keyword {keyWord}.");
            }
            return placesFound.ToList();
        }

        public Place EditPlace(Place place)
        {
            PlaceController.Edit(place);
            return place;
        }

        public void DeletePlace(Place place)
        {
            PlaceController.Delete(place);
        }
        public Place AttachFile(Place place, User userWhoAttach, FileBase file)
        {
            var fileToPlace = new FileContainer()
            {
                File = file,
                PlaceWhereAttached = place,
                UserWhoAttached = userWhoAttach,
                Path = file.Path
            };
            place.Media.Add(fileToPlace);
            userWhoAttach.FilesAttached.Add(fileToPlace);

            PlaceController.Edit(place);
            return place;
        }
        public Place AddComment(Place placeWhereLeft, User userWhoLeft, string content)
        {
            var comment = new Comment()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft,
                Created = DateTime.Now,
            };
            placeWhereLeft.Comments.Add(comment);

            PlaceController.Edit(placeWhereLeft);

            return placeWhereLeft;
        }

    }
}
