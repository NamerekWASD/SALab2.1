using DAL.Controllers;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;
using SALab2._1.Exceptions;
using System.Web.Mvc;

namespace SALab2._1.Service.Base
{
    public class UserService : IUserService
    {
        private static UserController UserController = new();
        public User SignIn(string name, string surname, string email, string password, Role role)
        {
            var user = new User()
            {
                Name = name,
                Surname = surname,
                AuthentificationData = new()
                {
                    Email = email.ToLower(),
                    Password = password,
                },
                PersonRole = role
            };
            UserController.Create(user);
            return user;
        }
        public User LogIn(string email, string password)
        {
            return UserController.LogIn(email, password);
        }
        public void UpdateUser(User user)
        {
            UserController.Edit(user);
        }

        public void DeleteUser(User user)
        {
            UserController.Delete(user);
        }
        public void MakeRequest(Place placeWhereLeft, User userWhoLeft, string content)
        {
            var question = new Request()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft
            };
            placeWhereLeft.Requests.Add(question);

            UserController.Edit(userWhoLeft);
        }
    }
}
