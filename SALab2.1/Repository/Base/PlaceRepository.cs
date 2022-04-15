using DAL.Context;
using DAL.Entities.PlaceEntity;

namespace SALab2._1.Repository.Base
{
    public class PlaceRepository : IPlaceRepository
    {
        public void Add(Place place)
        {
            using (PlaceContext db = new())
            {
                db.Add(place);
                db.SaveChanges();

            }
        }

        public List<Place> Get(string name)
        {
            using (PlaceContext db = new())
            {
                var place = from p in db.Places
                            where p.Name.ToLower().Contains(name.ToLower())
                            select p;
                return place.ToList();
            }
        }
        public List<Place> Get()
        {
            using (PlaceContext db = new())
            {
                return db.Places.ToList();
            }
        }

        public void Delete(Place place)
        {
            using (PlaceContext db = new())
            {
                var placeToDelete = db.Places.FirstOrDefault(x => x.Id == place.Id);
                if (placeToDelete is null)
                {
                    return;
                }

                db.Places.Remove(placeToDelete);
                db.SaveChanges();
            }
        }

        public void Update(Place newPlace)
        {
            using (PlaceContext db = new())
            {
                var placeToEdit = db.Places.FirstOrDefault(x => x.Id == newPlace.Id);

                if(placeToEdit is null)
                {
                    return ;
                }

                placeToEdit.Name = newPlace.Name;
                placeToEdit.UniqueName = newPlace.UniqueName;
                placeToEdit.Category = newPlace.Category;
                placeToEdit.Comments = newPlace.Comments;
                placeToEdit.Location = newPlace.Location;
                db.Places.Update(placeToEdit);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// If place with such unique name exists, return true, else false.
        /// </summary>
        /// <param name="placeUniqueName"></param>
        /// <returns></returns>
        public bool CheckPlaceForExistence(string placeUniqueName)
        {
            using(PlaceContext db = new())
            {
                var Found = from p in db.Places
                            where p.UniqueName == placeUniqueName
                            select p;
                if(Found is null || Found.Count() is 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
