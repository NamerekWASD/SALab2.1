using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private int status = 0;
        public int Status { get { return status; } set { status = value; } }
        public bool IsManager
        {
            get
            {
                if (status is 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                status = value ? 1 : 0;
            }
        }
        public Role PersonRole
        {
            set
            {
                if (value.GetRole == new Manager().GetRole)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }
        }
        public UserViewModel User { get; set; }

        public abstract class Role
        {
            private static string personRole = string.Empty;
            public string GetRole { get { return personRole; } protected set => personRole = value; }
        }
        public class Manager : Role
        {
            public Manager()
            {
                GetRole = "Manager";
            }
        }
        public class UserWithoutPermission : Role
        {
            public UserWithoutPermission()
            {
                GetRole = "User";
            }
        }
    }
}
