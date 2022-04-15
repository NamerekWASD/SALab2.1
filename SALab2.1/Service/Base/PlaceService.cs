using DAL.Entities.CommentEntity;
using DAL.Entities.MediaEntity.Base;
using DAL.Entities.MediaEntity.MatchingToPlace;
using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;
using SALab2._1.Exceptions;
using SALab2._1.Repository;
using SALab2._1.Repository.Base;

namespace SALab2._1.Service.Base
{
    public class PlaceService : IPlaceService
    {
        private static IPlaceRepository PlaceRepository = new PlaceRepository();
        private static IUserRepository UserRepository = new UserRepository();
        public void AddPlace(string name,string category, string uniqueName, string location)
        {
            if (PlaceRepository.CheckPlaceForExistence(uniqueName))
            {
                throw new ExistencePlaceException($"Place with this unique name {uniqueName} already exists!");
            }
            PlaceRepository.Add(new Place()
            {
                Name = name,
                Category = category,
                UniqueName = uniqueName,
                Location = location,
            });
        }

        public List<Place> GetPlacesByKeyWord(string keyWord)
        {
            var placesFound = PlaceRepository.Get(keyWord);
            if (placesFound is null || placesFound.Count == 0)
            {
                throw new Exception($"Nothing found by keyword {keyWord}.");
            }
            return placesFound;
        }

        public void UpdatePlace(Place place)
        {
            if(PlaceRepository.CheckPlaceForExistence(place.UniqueName))
            {
                throw new ExistencePlaceException($"Place with this unique name {place.UniqueName} already exists!");
            }
            PlaceRepository.Update(place);
        }

        public void DeletePlace(Place place)
        {
            if (PlaceRepository.CheckPlaceForExistence(place.UniqueName))
            {
                throw new Exception($"Place {place.Name} does not exist.");
            }
            PlaceRepository.Delete(place);
        }
        public void AttachFile(Place place, User userWhoAttach, FileBase file)
        {
            var fileToPlace = new FileAdapter()
            {
                File = file,
                PlaceWhereAttached = place,
                UserWhoAttached = userWhoAttach,
                Path = file.Path
            };
            place.Media.Add(fileToPlace);
            userWhoAttach.FilesAttached.Add(fileToPlace);

            PlaceRepository.Update(place);
            UserRepository.Update(userWhoAttach);
        }
        public void AddComment(Place placeWhereLeft, User userWhoLeft, string content)
        {
            var comment = new Comment()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft,
                Created = DateTime.Now,
            };
            placeWhereLeft.Comments.Add(comment);
            userWhoLeft.LeftComments.Add(comment);

            PlaceRepository.Update(placeWhereLeft);
            UserRepository.Update(userWhoLeft);
        }
        public void AddQuestion(Place placeWhereLeft, User userWhoLeft, string content)
        {
            var question = new Question()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft
            };
            placeWhereLeft.Questions.Add(question);


            PlaceRepository.Update(placeWhereLeft);
        }

    }
}
