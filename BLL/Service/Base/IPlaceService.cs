using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.MatchingToPlace;

namespace SALab2._1.Service
{
    public interface IPlaceService
    {
        IEnumerable<PlaceDTO> GetPlacesByKeyWord(string keyWord);
        void DeletePlace(PlaceDTO place);
        PlaceDTO AddPlace(string name, string category, string uniqueName, string location);
        PlaceDTO EditPlace(PlaceDTO place);
        PlaceDTO AttachFile(PlaceDTO place, UserDTO userWhoAttach, FileContainerDTO fileBase);
        PlaceDTO AddComment(PlaceDTO placeWhereLeft, UserDTO userWhoLeft, string content);
    }
}
