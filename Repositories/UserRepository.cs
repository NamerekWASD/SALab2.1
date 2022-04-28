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

        public void Create(UserModel data)
        {
            if (CheckEmailExistence(data.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }

            db.Users.Add(data);
        }

        public UserModel Get(int id)
        {
            return db.Users.Single(x => x.Id == id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return db.Users;
        }

        public void Delete(UserModel data)
        {
            db.Users.Remove(data);
        }

        public void Update(UserModel data)
        {
            if (CheckEmailExistence(data.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }
            db.Entry(data).State = EntityState.Modified;
        }
        /// <summary>
        /// If email exist, return true, else false
        /// </summary>
        /// <param name="email">
        /// Email to check
        /// </param>
        private bool CheckEmailExistence(string email)
        {
            var Found = from u in db.UsersProfile
                        where u.UserData.Email == email.ToLower()
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
