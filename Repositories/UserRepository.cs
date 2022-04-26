using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Models.UserModels;
using Repositories.Base;
using SALab2._1.Exceptions;

namespace Repositories
{
    public class UserRepository : IRepository<UserModel>
    {

        private PlaceContext db;
        public UserRepository(PlaceContext db)
        {
            this.db = db;
        }

        public void Create(UserModel user)
        {
            if (CheckEmailExistence(user.AuthentificationData.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }

            db.Users.Add(user);
        }

        public UserModel Get(int id)
        {
            return db.Users.Single(x => x.Id == id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return db.Users;
        }

        public void Delete(UserModel user)
        {
            db.Users.Remove(user);
        }

        public void Update(UserModel newUser)
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
