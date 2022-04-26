using DAL.Context;
using Repositories;

namespace UoW
{
    public class UnitOfWork : IDisposable
    {
        private PlaceContext db = new();
        private PlaceRepository PlaceRepository;
        private UserRepository UserRepository;

        public PlaceRepository Places
        {
            get
            {
                if (PlaceRepository == null)
                    PlaceRepository = new PlaceRepository(db);
                return PlaceRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepository(db);
                return UserRepository;
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
