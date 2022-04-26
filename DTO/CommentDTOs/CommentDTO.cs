using DTO.PlaceDTOs;
using DTO.UserDTOs;

namespace DTO.CommentDTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public UserDTO UserWhoLeft { get; set; }
        public PlaceDTO PlaceWhereLeft { get; set; }
    }
}
