using DAL.Entities.PlaceEntity;

namespace SALab2._1.Repository
{
    internal interface IPlaceRepository
    {
        void Add(Place place);
        void Delete(Place place);
        void Update(Place newPlace);
        List<Place> Get(string keyword);
        List<Place> Get();
        bool CheckPlaceForExistence(string placeUniqueName);
    }
}
