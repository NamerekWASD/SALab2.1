

namespace Models
{
    public class RequestStoreModel
    {
        public int Id { get; set; }
        public virtual PlaceModel Place { get; set; }
        public virtual RequestedPlace? RequestedPlace { get; set; }
        public string? UserWhoAddedRequest { get; set; }
        public bool IsCreated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
