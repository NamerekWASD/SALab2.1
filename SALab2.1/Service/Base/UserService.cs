using DAL.Entities.PersonEntity;
using SALab2._1.Exceptions;
using SALab2._1.Repository;
using SALab2._1.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.Service.Base
{
    internal class UserService : IUserService
    {
        private static IUserRepository UserRepository = new UserRepository();
        public User SignIn(string name, string surname, string email, string password, Role role)
        {
            if (UserRepository.CheckEmailExistence(email))
            {
                throw new ExistenceEmailException($"User with this email {email} already exists!");
            }
            var user = new User()
            {
                Name = name,
                Surname = surname,
                Email = email.ToLower(),
                Password = password,
                PersonRole = role
            };
            UserRepository.Add(user);
            return user;
        }
        public User LogIn(string email, string password)
        {
            return UserRepository.Get(email, password);
        }
        public void UpdateUser(User user)
        {
            if (UserRepository.CheckEmailExistence(user.Email))
            {
                throw new ExistenceEmailException($"User with this email {user.Email} already exists!");
            }
            UserRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            UserRepository.Delete(user);
        }
    }
}
