using DTO.PlaceDTOs;
using DTO.UserDTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.MediaModel.MatchingToPlace
{
    public class FileContainerDTO
    {
        public int Id { get; set; }
        private string _path;
        public string Path { get { return _path; } set { _path = value; } }
        public UserDTO UserWhoAttached { get; set; }
        public PlaceDTO PlaceWhereAttached { get; set; }
    }
}
