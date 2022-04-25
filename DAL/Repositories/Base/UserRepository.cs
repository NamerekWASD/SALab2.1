using DAL.Context;
using DAL.Models.PersonEntity;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using SALab2._1.Exceptions;

namespace DAL.Repositories.Base
{
    public class UserRepository : IRepository<User>
    {

        private PlaceContext db;
        public UserRepository(PlaceContext db)
        {
            this.db = db;
        }

        public void Create(User user)
        {
            if (CheckEmailExistence(user.AuthentificationData.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }

            db.Users.Add(user);
        }

        public User Get(int id)
        {
            return db.Users.Single(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Delete(User user)
        {
            db.Users.Remove(user);
        }

        public void Update(User newUser)
        {
            if (CheckEmailExistence(newUser.AuthentificationData.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }
            db.Entry(newUser).State = EntityState.Modified;
        }
        /// <summary>
        /// If email exist, return true, else false
        /// </summary>
        /// <param name="email">
        /// Email to check
        /// </param>
        private bool CheckEmailExistence(string email)
        {
            var Found = from u in db.Users
                        where u.AuthentificationData.Email == email.ToLower()
                        select u;
            if (Found.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
