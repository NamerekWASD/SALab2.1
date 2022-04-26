using DTO.PlaceDTOs;
using DTO.UserDTOs;

namespace BLL.Service.Base
{
    public interface IUserService
    {
        UserDTO LogIn(string email, string password);
        UserDTO SignIn(string name, string surname, string email, string password);
        void UpdateUser(UserDTO user);
        void DeleteUser(UserDTO user);
    }
}