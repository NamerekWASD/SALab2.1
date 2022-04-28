using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using Models.MediaModel.MatchingToPlace;

namespace DTO.UserDTOs
{

    public sealed class UserProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public List<FileContainerDTO>? FilesAttached { get; set; }
        public List<CommentDTO>? LeftComments { get; set; }
        public List<PlaceDTO>? VisitedPlaces { get; set; }
        public UserDTO? UserData { get; set; }

    }
}
