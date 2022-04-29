using BLL.Controllers;
using BLL.Service.Base;
using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Exceptions;
using Services.GeneralMappers;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private static UserController UserController = new();
        public UserProfileDTO SignIn(string name, string surname, string email, string password)
        {
            var user = new UserDTO()
            {
                Email = email.ToLower(),
                Password = password,
                IsManager = true,
                UserProfile = new()
                {
                    Name = name,
                    Surname = surname,
                }
            };
            UserController.Create(user.ToModel());
            return user.UserProfile;
        }
        public UserProfileDTO LogIn(string email, string password)
        {
            return UserController.LogIn(email, password).ToDTO();
        }
        public void Edit(UserProfileDTO user)
        {
            UserController.Update(user.ToModel());
        }

        public void DeleteUser(UserProfileDTO user)
        {
            UserController.Delete(user.ToModel());
        }

        public UserProfileDTO AddVisitedPlace(UserProfileDTO user, PlaceDTO placeToAdd)
        {
            var userVisitedPlaces = user.VisitedPlaces;

            if(userVisitedPlaces is not null &&
                userVisitedPlaces.Any() 
                && userVisitedPlaces
                .Select(p => p.Id == placeToAdd.Id)
                .Any())
            {
                throw new ExistingItemInCollectionException("This place already visited!");
            }

            user.VisitedPlaces!.Add(placeToAdd);

            UserController.Update(user.ToModel());

            return user;
        }
    }
}
