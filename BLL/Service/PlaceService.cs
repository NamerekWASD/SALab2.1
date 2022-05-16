using BLL.Service.Base;
using DTO;
using Exceptions;
using Services.GeneralMappers;
using UoW;

namespace BLL.Service
{
    public class PlaceService : IPlaceService
    {
        private static readonly UnitOfWork UoW = new();
        public PlaceDTO AddPlace(string name, string category, string country, string city)
        {
            var place = CheckPlaceExist(name);
            if(place != null)
            {
                ObjectExist();
            }
            place = new()
            {
                Name = name,
                Category = category,
                Country = country,
                City = city,
            };
            UoW.Places.Create(place.ToModel());
            UoW.Save();
            return place;
        }

        public List<PlaceDTO> GetPlacesByKeyWord(string keyWord)
        {
            var placesFound = from p in UoW.Places.GetAll()
                              .ToList()
                              .ToDTO()
                              where p.Name.Contains(keyWord)
                              select p;

            if (placesFound is null || !placesFound.Any())
            {
                NotFound();
            }
            return placesFound.ToList();
        }
        public PlaceDTO GetPlaceById(int? id)
        {
            var place = CheckPlaceExist(id);
            if( place == null)
            {
                NotFound();
            }
            return place;  
        }
        public PlaceDTO EditPlace(PlaceDTO place)
        {
            var foundPlace = CheckPlaceExist(place.Id);
            if(foundPlace == null)
            {
                NotFound();
            }
            UoW.Places
                .Update(place.ToModel());
            UoW.Save();
            return place;
        }
        public List<PlaceDTO> GetAll()
        {
            var places = UoW.Places
                .GetAll()
                .ToList()
                .ToDTO();
            if (places == null || !places.Any())
            {
                NotFound();
            }
            return places;
        }

        public PlaceDTO DeletePlace(int? id)
        {
            var place = CheckPlaceExist(id);
            if (place == null)
            {
                NotFound();
            }
            UoW.Places
                .Delete(place.ToModel());
            UoW.Save();
            return place;
        }
        private PlaceDTO CheckPlaceExist(int? id)
        {
            if(id == null)
            {
                return null;
            }
            var place = UoW.Places
                .Get(id)
                .ToDTO();
            if (place == null)
            {
                return null;
            }
            return place;
        }
        private PlaceDTO CheckPlaceExist(string? name)
        {
            if(name == null)
            {
                return null;
            }
            var places = UoW.Places
                .GetAll()
                .ToList()
                .ToDTO();
            if(places == null)
            {
                return null;
            }
            var place = places.FirstOrDefault(x => x.Name == name);
            if(place == null)
            {
                return null;
            }
            return place;
        }
        private void NotFound()
        {
            throw new NotFoundException("Place(-s) did not found");
        }

        private void ObjectExist()
        {
            throw new ExistingObjectException("Object already exist");
        }

    }
}
