using BLL.Service.Base;
using DTO;
using UoW;
using Services.GeneralMappers;
using Exceptions;

namespace BLL.Service
{
    public class RequestService : IRequestService
    {
        private static readonly UnitOfWork UoW = new();

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
            if (id == null)
            {
                return null;
            }
            var request = UoW.Requests
                .Get(id)
                .ToDTO();
            if(request == null)
            {
                return null;
            }
            return request;
        }
        public RequestStoreDTO AcceptManager(RequestStoreDTO request)
        {

            var place = request.Place;
            if (place == null)
            {
                NotFound();
            }

            if (request.IsCreated)
            {
                UoW.Places.Create(place.ToModel());
            }
            if (request.IsEdited)
            {
                var editedPlace = request.RequestedPlace;
                place = new()
                {
                    Id = place.Id,
                    Name = editedPlace.Name,
                    Category = editedPlace.Category,
                    City = editedPlace.City,
                    Country = editedPlace.Country,
                    Comments = editedPlace.Comments,
                    Media = editedPlace.Media,
                };
                UoW.Places.Update(place.ToModel());
            }
            if (request.IsDeleted)
            {
                UoW.Places.Delete(place.ToModel());
            }
            DeleteRequest(request.Id);

            return request;
            
        }
        private void NotFound()
        {
            throw new NotFoundException("Place did not found");
        }
    }
}
