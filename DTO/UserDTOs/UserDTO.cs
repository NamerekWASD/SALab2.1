using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsManager { get; set; }
        public string Status => IsManager ? "Manager" : "User" ;
        public int UserId { get; set; }
        public UserProfileDTO UserProfile { get; set; }
    }
}
