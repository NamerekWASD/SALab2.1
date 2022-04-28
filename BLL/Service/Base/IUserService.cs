using DTO.PlaceDTOs;
using DTO.UserDTOs;

namespace BLL.Service.Base
{
    public interface IUserService
    {
        UserProfileDTO LogIn(string email, string password);
        UserProfileDTO SignIn(string name, string surname, string email, string password);
        void UpdateUser(UserProfileDTO user);
        void DeleteUser(UserProfileDTO user);
    }
}