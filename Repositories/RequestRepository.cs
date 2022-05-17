using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;

namespace Repositories
{
    public class RequestRepository : IRepository<RequestStoreModel>
    {
        private ApplicationDbContext db;
        public RequestRepository(ApplicationDbContext db) { this.db = db; }
        public void Create(RequestStoreModel request)
        {
            db.Requests.Add(request);
        }

        public RequestStoreModel Get(int? id)
        {
            return db.Requests.Single(x => x.Id == id);
        }
        public IEnumerable<RequestStoreModel> GetAll()
        {
            return db.Requests;
        }

        public void Delete(RequestStoreModel request)
        {

            RequestStoreModel req = db.Requests.FirstOrDefault(r => r.Id == request.Id);

            if (req != null)
            {
                db.Requests.Remove(req);
                CascadeRequestPlaceDelete(req);
            }
        }

        public void Update(RequestStoreModel newPlace)
        {
            db.Entry(newPlace).State = EntityState.Modified;
        }
        private void CascadeRequestPlaceDelete(RequestStoreModel request)
        {
            if (request.RequestedPlace != null)
            {
                var reqPlace = db.RequestedPlaces.FirstOrDefault(p => p.Id == request.RequestedPlace.Id);
                if(reqPlace != null)
                {
                    db.RequestedPlaces.Remove(reqPlace);
                }
            }
        }
    }
}
