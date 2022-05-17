using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlaceMapper
{
    public static class Request
    {
        public static PlaceDTO ToDTOIncludeId(this RequestedPlaceDTO place)
        {
            return new()
            {
                Id = place.Id,
                Name = place.Name,
                Country = place.Country,
                Category = place.Category,
                City = place.City,
            };
        }
        public static PlaceDTO ToDTO(this RequestedPlaceDTO place)
        {
            return new()
            {
                Name = place.Name,
                Country = place.Country,
                Category = place.Category,
                City = place.City,
            };
        }
    }
}
