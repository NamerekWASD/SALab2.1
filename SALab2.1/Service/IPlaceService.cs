using DAL.Entities.MediaEntity.Base;
using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;

namespace SALab2._1.Service
{
    public interface IPlaceService
    {
        List<Place> GetPlacesByKeyWord(string keyWord);
        void DeletePlace(Place place);
        void AddPlace(string name, string category, string uniqueName, string location);
        void UpdatePlace(Place place);
        void AttachFile(Place place, User userWhoAttach, FileBase fileBase);
        void AddComment(Place placeWhereLeft, User userWhoLeft, string content);
        void AddQuestion(Place placeWhereLeft, User userWhoLeft, string content);
    }
}
