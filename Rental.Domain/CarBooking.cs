using System;

namespace Rental.Domain
{
    public class CarBooking
    {
        public Car Car { get; set; }
        public Account Account { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
