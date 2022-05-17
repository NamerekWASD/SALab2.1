using BLL.Service;
using BLL.Service.Base;
using DTO;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ModuleTests
{
    [TestClass]
    public class PlaceServiceTests
    {
        private const string TestConnectionString = "Server=(localdb)\\mssqllocaldb;Database=PCOTestdb;Trusted_Connection=True;";
        private IPlaceService placeService = new PlaceService(TestConnectionString);
        [TestMethod]
        public void AddingPlace()
        {
            // Arrange
            var place = CreateTestPlace();
            // Act
            placeService.AddPlace(place.Name, place.Category, place.Country, place.City);
            var placeFromDB = placeService.GetPlaceById(place.Id);

            // Assert
            Assert.AreEqual(place.Id, placeFromDB.Id);
            Assert.AreEqual(place.Name, placeFromDB.Name);
            Assert.AreEqual(place.Category, placeFromDB.Category);
            Assert.AreEqual(place.Country, placeFromDB.Country);
            Assert.AreEqual(place.City, placeFromDB.City);
        }
        [TestMethod]
        public void AddingExistingPlace()
        {
            // Arrange
            var place = CreateTestPlace();
            placeService.AddPlace(place.Name, place.Category, place.Country, place.City);
            try 
            {
                // Act
                placeService.AddPlace(place.Name, place.Category, place.Country, place.City);
            }
            catch (ExistingObjectException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, "exist");
            }
        }
        [TestMethod]
        public void EditingExistingPlace()
        {
            // Arrange
            var place = CreateTestPlace();
            placeService.AddPlace(place.Name, place.Category, place.Country, place.City);

            // Act
            var placeFromDB = placeService.GetPlaceById(place.Id);
            string newName = "Wal Street";
            placeFromDB.Name = newName;
            placeService.EditPlace(placeFromDB);
            placeService.GetPlaceById(place.Id);

            // Assert
            Assert.AreNotEqual(place.Name, placeFromDB.Name);
        }
        [TestMethod]
        public void DeletingPlaceFromDb()
        {
            // Arrange
            var place = CreateTestPlace();
            placeService.AddPlace(place.Name, place.Category, place.Country, place.City);

            //Act
            placeService.DeletePlace(place.Id);
            PlaceDTO nullPlace = null;
            //Assert
            try
            {
                nullPlace = placeService.GetPlaceById(place.Id);
            }catch (NotFoundException ex)
            {
                StringAssert.Contains(ex.Message, "did not found");
            }
            Assert.IsNull(nullPlace);
        }
        [TestMethod]
        public void GettingSeveralPlacesFromDBUsingKeyword()
        {
            // Arrange
            var places = CreateTestListPlace();
            placeService.AddPlace(places[0].Name, places[0].Category, places[0].Country, places[0].City);
            placeService.AddPlace(places[1].Name, places[1].Category, places[1].Country, places[1].City);
            placeService.AddPlace(places[2].Name, places[2].Category, places[2].Country, places[2].City);
            placeService.AddPlace(places[3].Name, places[3].Category, places[3].Country, places[3].City);

            // Act
            string keyword = "tower";
            var foundPlaces = placeService.GetPlacesByKeyWord(keyword);

            // Assert
            Assert.AreEqual(2, foundPlaces.Count);
        }
        [TestMethod]
        public void GettingAllPlacesFromDB()
        {
            // Arrange
            var places = CreateTestListPlace();
            placeService.AddPlace(places[0].Name, places[0].Category, places[0].Country, places[0].City);
            placeService.AddPlace(places[1].Name, places[1].Category, places[1].Country, places[1].City);
            placeService.AddPlace(places[2].Name, places[2].Category, places[2].Country, places[2].City);
            placeService.AddPlace(places[3].Name, places[3].Category, places[3].Country, places[3].City);

            // Act
            var AllPlaces = placeService.GetAll();

            // Assert
            Assert.AreEqual(places.Count, AllPlaces.Count);
        }
        private PlaceDTO CreateTestPlace()
        {
            return new()
            {
                Id = 1,
                Name = "Wall Street",
                Category = "Street",
                Country = "USA",
                City = "New-York"
            };
        }
        private List<PlaceDTO> CreateTestListPlace()
        {
            return new()
            {
                    new PlaceDTO
                    {
                        Id=1,
                        Name = "Maidan Nezalezhnosti",
                        Category = "Square",
                        Country = "Ukraine",
                        City = "Kiev",
                    },

                    new PlaceDTO
                    {
                        Id = 2,
                        Name = "St. Sophia's Cathedral",
                        Category = "Museum",
                        Country = "Ukraine",
                        City = "Kiev",
                    },

                    new PlaceDTO
                    {
                        Id = 3,
                        Name = "Rhine Tower Dusseldorf",
                        Category = "Museum",
                        Country = "Germany",
                        City = "Dusseldorf",
                    },

                    new PlaceDTO
                    {
                        Id = 4,
                        Name = "Tower of Pisa",
                        Category = "Building",
                        Country = "Italy",
                        City = "Pisa",
                    },
        };
        }
    }
}