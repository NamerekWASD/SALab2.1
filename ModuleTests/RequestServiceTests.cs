using BLL.Service;
using BLL.Service.Base;
using DAL.Contexts;
using DTO;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModuleTests
{
    [TestClass]
    public class RequestServiceTests
    {
        private static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=PCOTestdb;Trusted_Connection=True;MultipleActiveResultSets=true";
        [TestMethod]
        public void AddingCreateRequestToDB()
        {
            // Arrange
            ITestingRequestService requestService = new RequestService(ConnectionString);
            var place = CreateTestPlace();

            string userName = "Nikola";

            // Act
            requestService.AddCreateRequest(ToRequested(place), userName);

            var requests = requestService.GetRequests();

            // Assert
            Assert.AreEqual(1, requests.Count);

            Assert.AreEqual(1, requests[0].RequestedPlace.Id);

            Assert.AreEqual(place.Name, requests[0].RequestedPlace.Name);
        }
        [TestMethod]
        public void AddingCreateRequestToDBAndAcceptingIt()
        {
            // Arrange
            IPlaceService placeService = new PlaceService(ConnectionString);
            ITestingRequestService requestService = new RequestService(ConnectionString);
            var place = CreateTestPlace();

            string userName = "Nikola";

            // Act
            requestService.AddCreateRequest(ToRequested(place), userName);

            requestService.AcceptRequest(1);

            var foundPlace = placeService.GetPlaceById(1);

            // Assert
            Assert.IsNotNull(foundPlace);

            Assert.AreEqual(place.Name, foundPlace.Name);

            Assert.AreEqual(place.Category, foundPlace.Category);

            Assert.AreEqual(place.Country, foundPlace.Country);

            Assert.AreEqual(place.City, foundPlace.City);

        }
        [TestMethod]
        public void AddingEditRequestToDBAndAcceptingIt()
        {
            // Arrange
            IPlaceService placeService = new PlaceService(ConnectionString);
            ITestingRequestService requestService = new RequestService(ConnectionString);
            var place = CreateTestPlace();
            string userName = "Nikola";

            // Act
            var editedPlace = ToRequested(place);

            editedPlace.Name = "Wal Strit";

            requestService.AddEditRequest(place, userName, editedPlace);

            requestService.AcceptRequest(1);

            var placeFromDb = placeService.GetPlaceById(1);

            // Assert
            Assert.AreNotEqual(place.Name, placeFromDb.Name);
        }
        [TestMethod]
        public void AddingDeleteRequestToDBAndAcceptingIt()
        {
            // Arrange
            IPlaceService placeService = new PlaceService(ConnectionString);
            ITestingRequestService requestService = new RequestService(ConnectionString);
            var place = CreateTestPlace();
            string userName = "Nikola";

            // Act

            requestService.AddDeleteRequest(place, userName);

            requestService.AcceptRequest(1);

            PlaceDTO foundPlace = null;
            try
            {
                foundPlace = placeService.GetPlaceById(1);
            }
            catch (NotFoundException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, "did not found");
            }
            Assert.IsNull(foundPlace);
        }
        [TestMethod]
        public void AddingSomeRequestToDBAndDecliningIt()
        {
            // Arrange
            IPlaceService placeService = new PlaceService(ConnectionString);
            ITestingRequestService requestService = new RequestService(ConnectionString);
            var place = CreateTestPlace();
            string userName = "Nikola";

            // Act

            requestService.AddDeleteRequest(place, userName);

            requestService.DeclineRequest(1);

            PlaceDTO foundPlace = null;
            try
            {
                foundPlace = placeService.GetPlaceById(1);
            }
            catch (NotFoundException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, "did not found");
            }
            Assert.IsNotNull(foundPlace);
            Assert.AreEqual(place.Name, foundPlace.Name);
        }
        private PlaceDTO CreateTestPlace()
        {
            return new()
            {
                Name = "Wall Street",
                Category = "Street",
                Country = "USA",
                City = "New-York"
            };
        }
        private RequestedPlaceDTO ToRequested(PlaceDTO place)
        {
            return new()
            {
                Name = place.Name,
                Category = place.Category,
                Country = place.Country,
                City = place.City,
            };
        }
    }
}
