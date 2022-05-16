using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class FileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string UserWhoAttached { get; set; }
        public PlaceDTO PlaceWhereAttached { get; set; }
    }
}
