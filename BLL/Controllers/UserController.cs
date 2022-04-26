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

        public UserModel Get(int id)
        {
            return unitOfWork.Users.Get(id);
        }

        public void Create(UserModel u)
        {
            unitOfWork.Users.Create(u);
            unitOfWork.Save();
        }

        public void Edit(UserModel u)
        {
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public void Delete(UserModel u)
        {
            unitOfWork.Users.Delete(u);
            unitOfWork.Save();
        }


        [Authorize]
        public UserModel SignIn(string email, string password)
        {
            var user = new UserModel()
            {
                AuthentificationData = new()
                {
                    Email = email,
                    Password = password,
                }
            };
            Create(user);

            return user;
        }

        [Authorize]
        public UserModel LogIn(string email, string password)
        {
            var user = from u in unitOfWork.Users.GetAll()
                       where u.AuthentificationData.Email == email
                       && u.AuthentificationData.Password == password
                       select u;
            if (user.Any())
            {
                return user.FirstOrDefault();
            }
            else
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