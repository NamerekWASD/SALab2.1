using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;

namespace SALab2._1.Service
{
    public interface IUserService
    {
        User LogIn(string email, string password);
        User SignIn(string name, string surname, string email, string password, Role role);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void MakeRequest(Place placeWhereLeft, User userWhoLeft, string content);
    }
}