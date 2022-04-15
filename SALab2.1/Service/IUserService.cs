using DAL.Entities.PersonEntity;

namespace SALab2._1.Service
{
    public interface IUserService
    {
        User LogIn(string email, string password);
        User SignIn(string name, string surname, string email, string password, Role role);
        void UpdateUser(User user);
    }
}