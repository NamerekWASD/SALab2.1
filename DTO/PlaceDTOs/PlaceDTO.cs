using DTO.CommentDTOs;
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

        public List<CommentDTO>? Comments { get; set; }
        public List<FileContainerDTO>? Media { get; set; }
    }
}
