using DTO.PlaceDTOs;
using DTO.UserDTOs;
using Models.MediaModel.MatchingToPlace;

namespace BLL.Service.Base
{
    public interface IPlaceService
    {
        List<PlaceDTO> GetPlacesByKeyWord(string keyWord);
        void DeletePlace(PlaceDTO place);
        PlaceDTO AddPlace(string name, string category, string uniqueName, string location);
        PlaceDTO EditPlace(PlaceDTO place);
        PlaceDTO AttachFile(PlaceDTO place, UserProfileDTO userWhoAttach, FileContainerDTO fileBase);
        PlaceDTO AddComment(PlaceDTO placeWhereLeft, UserProfileDTO userWhoLeft, string content);
        PlaceDTO AddReply(PlaceDTO placeWhereLeft, UserProfileDTO userWhoLeft, int onReplyCommentId, string content);
    }
}
