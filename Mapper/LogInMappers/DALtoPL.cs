using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.UserViewModels;

namespace Mapper.LogInMappers
{
    public static class DALtoPL
    {
        public static LoginViewModel ToViewModel(this LoginModel data)
        {
            return new()
            {
                Id = data.Id,
                Password = data.Password,
                Email = data.Email,
                UserId = data.UserId
            };
        }
    }
}
