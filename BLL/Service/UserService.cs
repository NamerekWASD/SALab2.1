using BLL.Controllers;
using BLL.Service.Base;
using DTO.UserDTOs;
using Services.GeneralMappers;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private static UserController UserController = new();
        public UserProfileDTO SignIn(string name, string surname, string email, string password)
        {
            var user = new UserDTO()
            {
                Email = email.ToLower(),
                Password = password,
                IsManager = true,
                UserProfile = new()
                {
                    Name = name,
                    Surname = surname,
                }
            };
            UserController.Create(user.ToModel());
            return user.UserProfile;
        }
        public UserProfileDTO LogIn(string email, string password)
        {
            return UserController.LogIn(email, password).ToDTO();
        }
        public void UpdateUser(UserProfileDTO user)
        {
            UserController.Edit(user.ToModel());
        }

        public void DeleteUser(UserProfileDTO user)
        {
            UserController.Delete(user.ToModel());
        }
    }
}
