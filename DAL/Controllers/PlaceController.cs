using DAL.Models.PlaceEntity;
using DAL.UnitsOfWork;
using System.Web.Mvc;

namespace DAL.Controllers
{
    public class PlaceController : Controller
    {
        UnitOfWork unitOfWork;
        public PlaceController()
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<Place> Index()
        {
            return unitOfWork.Places.GetAll();
        }
        public Place Get(int id)
        {
            return unitOfWork.Places.Get(id);
        }

        public void Create(Place p)
        {
            unitOfWork.Places.Create(p);
            unitOfWork.Save();
        }

        public void Edit(Place p)
        {
            unitOfWork.Places.Update(p);
            unitOfWork.Save();
        }

        public void Delete(Place p)
        {
            unitOfWork.Places.Delete(p);
            unitOfWork.Save();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
