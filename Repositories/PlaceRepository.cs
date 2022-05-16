using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;

namespace Repositories
{
    public class PlaceRepository : IRepository<PlaceModel>
    {
        private ApplicationDbContext db;
        public PlaceRepository(ApplicationDbContext db) { this.db = db; }
        public void Create(PlaceModel place)
        {
            db.Places.Add(place);
        }

        public PlaceModel Get(int? id)
        {
            return db.Places.Single(x => x.Id == id);
        }
        public IEnumerable<PlaceModel> GetAll()
        {
            return db.Places;
        }

        public void Delete(PlaceModel place)
        {

            PlaceModel pl = db.Places.FirstOrDefault(r => r.Id == place.Id);
            if (pl != null)
                db.Places.Remove(pl);
        }

        public void Update(PlaceModel newPlace)
        {
            Delete(newPlace);
            Create(newPlace);
        }
    }
}
