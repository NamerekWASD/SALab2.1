using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RequestStoreViewModel
    {
        public int Id { get; set; }
        public virtual PlaceViewModel? Place { get; set; }
        public virtual RequestedPlaceViewModel? RequestedPlace { get; set; }
        public string UserWhoAddedRequest { get; set; }
        public bool IsCreated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
        public override string ToString()
        {
            var str = $"Id: {Id}" +
                $"\nAction: ";
            if (IsCreated)
            {
                str += $"created;";
                str += $"\nCreated place: {RequestedPlace}";
            }
            if (IsEdited)
            {
                str += $"edited;" +
                    $"\nPrimal place: {Place}" +
                    $"\nEdited place: {RequestedPlace}";
            }
            if (IsDeleted)
            {
                str += $"deleted;";
            }
            return str;
        }
    }
}
