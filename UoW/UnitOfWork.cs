using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;
using Repositories.Base;


namespace UoW
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext db = new();
        private PlaceRepository PlaceRepository;
        private RequestRepository RequestRepository;
        public UnitOfWork() { }
        public UnitOfWork(string connectionString) {
            db = new(connectionString);
        }
        public IRepository<PlaceModel> Places
        {
            get
            {
                if (PlaceRepository == null)
                    PlaceRepository = new PlaceRepository(db);
                return PlaceRepository;
            }
        }
        public IRepository<RequestStoreModel> Requests
        {
            get
            {
                if (RequestRepository == null)
                    RequestRepository = new RequestRepository(db);
                return RequestRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
