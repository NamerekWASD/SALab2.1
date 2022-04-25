using DAL.Context;
using DAL.Models.PlaceEntity;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Base
{
    public class PlaceRepository : IRepository<Place>
    {
        private PlaceContext db;
        public PlaceRepository(PlaceContext db) { this.db = db; }
        public void Create(Place place)
        {
            db.Places.Add(place);
        }

        public Place Get(int id)
        {
            return db.Places.Single(x => x.Id == id);
        }
        public IEnumerable<Place> GetAll()
        {
            return db.Places;
        }

        public void Delete(Place place)
        {

            Place order = db.Places.Find(place);
            if (order != null)
                db.Places.Remove(order);
        }

        public void Update(Place newPlace)
        {
            db.Entry(newPlace).State = EntityState.Modified;
        }
    }
}
