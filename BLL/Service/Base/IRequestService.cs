using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Base
{
    public interface IRequestService
    {
        RequestStoreDTO AcceptRequest(int? id);
        RequestStoreDTO DeclineRequest(int? id);
        List<RequestStoreDTO> GetRequests();
    }
}
