using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO User { get; set; }
    }
}
