using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Models.PlaceModels;
using Repositories.Base;

namespace Repositories
{
    public class PlaceRepository : IRepository<PlaceModel>
    {
        private PlaceContext db;
        public PlaceRepository(PlaceContext db) { this.db = db; }
        public void Create(PlaceModel place)
        {
            db.Places.Add(place);
        }

        public PlaceModel Get(int id)
        {
            return db.Places.Single(x => x.Id == id);
        }
        public IEnumerable<PlaceModel> GetAll()
        {
            return db.Places;
        }

        public void Delete(PlaceModel place)
        {

            PlaceModel order = db.Places.Find(place);
            if (order != null)
                db.Places.Remove(order);
        }

        public void Update(PlaceModel newPlace)
        {
            db.Entry(newPlace).State = EntityState.Modified;
        }
    }
}
