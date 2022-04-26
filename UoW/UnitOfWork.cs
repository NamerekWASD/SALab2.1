using DAL.Context;
using Repositories;

namespace UoW
{
    public class UnitOfWork : IDisposable
    {
        private PlaceContext db = new();
        private PlaceRepository PlaceRepository;
        private AuthentificationRepository UserRepository;

        public PlaceRepository Places
        {
            get
            {
                if (PlaceRepository == null)
                    PlaceRepository = new PlaceRepository(db);
                return PlaceRepository;
            }
        }

        public AuthentificationRepository Usersdata
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new AuthentificationRepository(db);
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
