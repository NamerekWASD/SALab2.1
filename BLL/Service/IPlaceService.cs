using DAL.Models.MediaEntity.Base;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;

namespace SALab2._1.Service
{
    public interface IPlaceService
    {
        List<Place> GetPlacesByKeyWord(string keyWord);
        void DeletePlace(Place place);
        Place AddPlace(string name, string category, string uniqueName, string location);
        Place EditPlace(Place place);
        Place AttachFile(Place place, User userWhoAttach, FileBase fileBase);
        Place AddComment(Place placeWhereLeft, User userWhoLeft, string content);
    }
}
