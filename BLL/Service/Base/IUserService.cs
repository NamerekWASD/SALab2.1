
using DTO.PlaceDTOs;
using DTO.UserDTOs;

namespace SALab2._1.Service
{
    public interface IUserService
    {
        UserDTO LogIn(string email, string password);
        UserDTO SignIn(string name, string surname, string email, string password);
        void UpdateUser(UserDTO user);
        void DeleteUser(UserDTO user);
        void MakeRequest(PlaceDTO placeWhereLeft, UserDTO userWhoLeft, string content);
    }
}