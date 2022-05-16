using DTO;
using ViewModels;

namespace BLL.Service.Base
{
    public interface IPlaceService
    {
        List<PlaceDTO> GetPlacesByKeyWord(string keyWord);
        PlaceDTO DeletePlace(int? id);
        PlaceDTO AddPlace(string name, string category, string country, string city);
        PlaceDTO EditPlace(PlaceDTO place);
        PlaceDTO GetPlaceById(int? id);
        List<PlaceDTO> GetAll();
    }
}
