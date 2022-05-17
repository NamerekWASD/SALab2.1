using BLL.Service.Base;
using DTO;
using UoW;
using Services.GeneralMappers;
using Exceptions;
using Services.PlaceMapper;

namespace BLL.Service
{
    public class RequestService : IRequestService, ITestingRequestService
    {
        private static UnitOfWork UoW = new();
        public RequestService() { }
        // For tests
        public RequestService(string connectionString)
        {
            UoW = new(connectionString);
        }
        public List<RequestStoreDTO> GetRequests()
        {
            return UoW.Requests
                .GetAll()
                .ToList()
                .ToDTO();
        }
        public RequestStoreDTO AcceptRequest(int? id)
        {
            var request = CheckRequstExist(id);

            if (request == null)
            {
                NotFound();
            }
            return AcceptManager(request);
        }
        public RequestStoreDTO DeclineRequest(int? id)
        {
            return DeleteRequest(id);
        }
        private RequestStoreDTO DeleteRequest(int? id)
        {
            var request = CheckRequstExist(id);
            if(request == null)
            {
                NotFound();
            }

            UoW.Requests.Delete(request.ToModel());
            UoW.Save();
            return request;
        }
        private RequestStoreDTO CheckRequstExist(int? id)
        {
            RequestStoreDTO request = null;
            if (id == null)
            {
                return null;
            }
            try
            {
                request = UoW.Requests
                .Get(id)
                .ToDTO();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            if (request == null)
            {
                return null;
            }
            return request;
        }
        public RequestStoreDTO AcceptManager(RequestStoreDTO request)
        {

            if (request.IsCreated)
            {
                UoW.Places.Create(request.RequestedPlace.ToDTO().ToModel());
            }
            if (request.IsEdited)
            {
                var requestedPlace = request.RequestedPlace;
                if (requestedPlace == null)
                {
                    NotFound();
                }
                requestedPlace.Id = request.Place.Id;
                UoW.Places.Update(requestedPlace
                    .ToDTOIncludeId()
                    .ToModel());
            }
            if (request.IsDeleted)
            {
                var requestedPlace = request.Place;
                UoW.Places.Delete(requestedPlace.ToModel());
            }
            DeleteRequest(request.Id);

            return request;
            
        }
        private void NotFound()
        {
            throw new NotFoundException("Place did not found");
        }
        public void AddCreateRequest(RequestedPlaceDTO requestedPlace, string userName)
        {
            UoW.Requests.Create(new RequestStoreDTO()
            {
                RequestedPlace = requestedPlace,
                IsCreated = true,
            }.ToModel());
            UoW.Save();
        }
        public void AddEditRequest(PlaceDTO place, string userName, RequestedPlaceDTO requestedPlace)
        {
            UoW.Requests.Create(new RequestStoreDTO()
            {
                Place = place,
                RequestedPlace = requestedPlace,
                IsEdited = true,
            }.ToModel());
            UoW.Save();
        }
        public void AddDeleteRequest(PlaceDTO place, string userName)
        {
            UoW.Requests.Create(new RequestStoreDTO()
            {
                Place = place,
                IsDeleted = true,
            }.ToModel());
            UoW.Save();
        }
    }
}
