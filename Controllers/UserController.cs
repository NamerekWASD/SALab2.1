using Models.UserModels;
using SALab2._1.Exceptions;
using System.Web.Mvc;
using UoW;

namespace BLL.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitOfWork;
        public UserController()
        {
            unitOfWork = new UnitOfWork();
        }

        public void Create(UserModel u)
        {
            unitOfWork.Usersdata.Create(u);
            unitOfWork.Save();
        }

        public void Edit(UserProfileModel u)
        {
            unitOfWork.Usersdata.Update(u.UserData);
            unitOfWork.Save();
        }

        public void Delete(UserProfileModel u)
        {
            unitOfWork.Usersdata.Delete(u.UserData);
            unitOfWork.Save();
        }
        public UserProfileModel LogIn(string email, string password)
        {
            try
            {
                return unitOfWork.Usersdata.GetAll().Single(x => x.Email == email && x.Password == password).UserProfile;
            }
            catch (Exception e)
            {
                throw new IncorrectEmailOrPasswordException("Wrong email or password!");
            }

        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}