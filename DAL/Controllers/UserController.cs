using DAL.Models.PersonEntity;
using DAL.UnitsOfWork;
using SALab2._1.Exceptions;
using System.Web.Mvc;

namespace DAL.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitOfWork;
        public UserController()
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<User> Index()
        {
            return unitOfWork.Users.GetAll();
        }
        public User Get(int id)
        {
            return unitOfWork.Users.Get(id);
        }

        public void Create(User u)
        {
            unitOfWork.Users.Create(u);
            unitOfWork.Save();
        }

        public void Edit(User u)
        {
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public void Delete(User u)
        {
            unitOfWork.Users.Delete(u);
            unitOfWork.Save();
        }


        [Authorize]
        public User SignIn(string email, string password)
        {
            var user = new User()
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
        public User LogIn(string email, string password)
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