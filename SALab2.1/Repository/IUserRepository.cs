using DAL.Entities.PersonEntity;

namespace SALab2._1.Repository
{
    internal interface IUserRepository
    {
        void Add(User person);
        void Delete(User person);
        void Update(User newPerson);
        User Get(string email, string password);
        bool CheckEmailExistence(string email);
    }
}