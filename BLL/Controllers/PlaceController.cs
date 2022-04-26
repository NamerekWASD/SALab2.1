using Models.PlaceModels;
using System.Web.Mvc;
using UoW;

namespace BLL.Controllers
{
    public class PlaceController : Controller
    {
        UnitOfWork unitOfWork;
        public PlaceController()
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<PlaceModel> Index()
        {
            return unitOfWork.Places.GetAll();
        }
        public PlaceModel Get(int id)
        {
            return unitOfWork.Places.Get(id);
        }

        public void Create(PlaceModel p)
        {
            unitOfWork.Places.Create(p);
            unitOfWork.Save();
        }

        public void Edit(PlaceModel p)
        {
            unitOfWork.Places.Update(p);
            unitOfWork.Save();
        }

        public void Delete(PlaceModel p)
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
