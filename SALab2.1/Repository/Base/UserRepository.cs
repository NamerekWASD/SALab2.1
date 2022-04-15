using DAL.Context;
using DAL.Entities.PersonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.Repository.Base
{
    internal class UserRepository : IUserRepository
    {
        public void Add(User person)
        {
            using (PlaceContext db = new())
            {
                db.Add(person);
                db.SaveChanges();
            }
        }

        public User Get(string email, string password)
        {
            using (PlaceContext db = new())
            {
                return db.Users.Single(user => user.Email == email && user.Password == password);
            }
        }

        /// <summary>
        /// If email exist, return true, else false
        /// </summary>
        /// <param name="email">
        /// Email to check
        /// </param>
    public bool CheckEmailExistence(string email)
        {
            using (PlaceContext db = new())
            {
                var Found = from e in db.Users
                            where e.Email == email.ToLower()
                            select e;
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

        public void Delete(User user)
        {
            using (PlaceContext db = new())
            {
                var userToDelete = db.Users.FirstOrDefault(x => x.Id == user.Id);

                if (userToDelete == null)
                {
                    return;
                }
                db.Users.Remove(userToDelete);
                db.SaveChanges();
            }
        }

        public void Update(User newUser)
        {
            using (PlaceContext db = new())
            {
                var userToEdit = db.Users.FirstOrDefault(x => x.Id == newUser.Id);

                if(userToEdit == null)
                {
                    return ;
                }
                userToEdit.Name = newUser.Name;
                userToEdit.Surname = newUser.Surname;
                userToEdit.Email = newUser.Email;
                userToEdit.Password = newUser.Password;
                userToEdit.VisitedPlaces = newUser.VisitedPlaces;
                userToEdit.LeftComments = newUser.LeftComments;
                db.Users.Update(userToEdit);
                db.SaveChanges();
                Console.WriteLine("Edit Successfull!");
            }
        }
    }
}
