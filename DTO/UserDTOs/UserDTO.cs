using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using Models.MediaModel.MatchingToPlace;

namespace DTO.UserDTOs
{

    public sealed class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<FileContainerDTO> FilesAttached { get; set; }
        public ICollection<CommentDTO>? LeftComments { get; set; }
        public ICollection<PlaceDTO>? VisitedPlaces { get; set; }
        public LoginDTO AuthentificationData { get; set; }

    }
}
