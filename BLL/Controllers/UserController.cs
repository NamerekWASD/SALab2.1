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
        [Authorize]
        public void Create(UserModel u)
        {
            u.AuthentificationData.User = u;
            unitOfWork.Usersdata.Create(u.AuthentificationData);
            unitOfWork.Save();
        }

        public void Edit(UserModel u)
        {
            unitOfWork.Usersdata.Update(u.AuthentificationData);
            unitOfWork.Save();
        }

        public void Delete(UserModel u)
        {
            unitOfWork.Usersdata.Delete(u.AuthentificationData);
            unitOfWork.Save();
        }



        [Authorize]
        public UserModel LogIn(string email, string password)
        {
            try
            {
                return unitOfWork.Usersdata.GetAll().Single(x => x.Email == email && x.Password == password).User;
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