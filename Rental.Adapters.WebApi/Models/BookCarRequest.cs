using System;

namespace RentalApp.Adapters.WebApi.Models
{
    public class BookCarRequest
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
