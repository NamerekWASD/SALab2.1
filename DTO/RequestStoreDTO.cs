namespace DTO
{
    public class RequestStoreDTO
    {
        public int Id { get; set; }
        public PlaceDTO? Place { get; set; }
        public RequestedPlaceDTO? RequestedPlace { get; set; }
        public string UserWhoAddedRequest { get; set; }
        public bool IsCreated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
