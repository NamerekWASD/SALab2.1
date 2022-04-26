using BLL.Controllers;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Mappers.GeneralMappers;
using static DTO.PlaceDTOs.PlaceDTO;

namespace SALab2._1.Service.Base
{
    public class UserService : IUserService
    {
        private static UserController UserController = new();
        public UserDTO SignIn(string name, string surname, string email, string password)
        {
            var user = new UserDTO()
            {
                Name = name,
                Surname = surname,
                AuthentificationData = new()
                {
                    Email = email.ToLower(),
                    Password = password,
                },
            };
            UserController.Create(user.ToModel());
            return user;
        }
        public UserDTO LogIn(string email, string password)
        {
            return UserController.LogIn(email, password).ToDTO();
        }
        public void UpdateUser(UserDTO user)
        {
            UserController.Edit(user.ToModel());
        }

        public void DeleteUser(UserDTO user)
        {
            UserController.Delete(user.ToModel());
        }
        public void MakeRequest(PlaceDTO placeWhereLeft, UserDTO userWhoLeft, string content)
        {
            var question = new RequestDTO()
            {
                Content = content,
                UserWhoLeft = userWhoLeft,
                PlaceWhereLeft = placeWhereLeft
            };
            placeWhereLeft.Requests.Add(question);

            UserController.Edit(userWhoLeft.ToModel());
        }
    }
}
