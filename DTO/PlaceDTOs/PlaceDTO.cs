using DTO.CommentDTOs;
using DTO.UserDTOs;
using Models.MediaModel.MatchingToPlace;

namespace DTO.PlaceDTOs
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string UniqueName { get; set; }
        public string Location { get; set; }


        public ICollection<CommentDTO>? Comments { get; set; } = new List<CommentDTO>();
        public ICollection<RequestDTO>? Requests { get; set; } = new List<RequestDTO>();
        public ICollection<FileContainerDTO>? Media { get; set; } = new List<FileContainerDTO>();
        public class RequestDTO
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public PlaceDTO PlaceWhereLeft { get; set; }
            public UserDTO UserWhoLeft { get; set; }
        }
    }
}
