using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Models.UserModels;
using Repositories.Base;
using SALab2._1.Exceptions;

namespace Repositories
{
    public class AuthentificationRepository : IRepository<LoginModel>
    {

        private PlaceContext db;
        public AuthentificationRepository(PlaceContext db)
        {
            this.db = db;
        }

        public void Create(LoginModel data)
        {
            if (CheckEmailExistence(data.Email))
            {
                throw new ExistenceEmailException("Email already exists!");
            }

            db.LoginData.Add(data);
        }

        public LoginModel Get(int id)
        {
            return db.LoginData.Single(x => x.Id == id);
        }

        public IEnumerable<LoginModel> GetAll()
        {
            return db.LoginData;
        }

        public void Delete(LoginModel data)
        {
            db.LoginData.Remove(data);
        }

        public void Update(LoginModel data)
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
