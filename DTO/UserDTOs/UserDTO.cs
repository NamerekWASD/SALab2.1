using DTO.CommentDTOs;
using DTO.PlaceDTOs;
using Models.MediaModel.MatchingToPlace;

namespace DTO.UserDTOs
{

    public sealed class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        private int status = 0;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public ICollection<FileContainerDTO> FilesAttached { get; set; } = new List<FileContainerDTO>();
        public ICollection<CommentDTO>? LeftComments { get; set; } = new List<CommentDTO>();
        public ICollection<PlaceDTO>? VisitedPlaces { get; set; } = new List<PlaceDTO>();
        public LoginDTO AuthentificationData { get; set; }

    }
}
