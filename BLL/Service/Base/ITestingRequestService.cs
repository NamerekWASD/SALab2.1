using DTO;

namespace BLL.Service.Base
{
    public interface ITestingRequestService
    {
        void AddCreateRequest(RequestedPlaceDTO place, string userName);
        void AddEditRequest(PlaceDTO place, string userName, RequestedPlaceDTO requestedPlace);
        void AddDeleteRequest(PlaceDTO place, string userName);
        RequestStoreDTO AcceptRequest(int? id);
        RequestStoreDTO DeclineRequest(int? id);
        List<RequestStoreDTO> GetRequests();
    }
}