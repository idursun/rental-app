using System;
using Rental.Domain;

namespace Rental.Adapters.EF.Entities
{
    public class CarBookingEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public CarEntity Car { get; set; }

        public int AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public static class CarBookingEntityExtension
    {
        public static CarBooking ToDomain(this CarBookingEntity entity)
        {
            return new CarBooking
            {
                Account = new Account(),
                Car = entity.Car.ToDomain(),
                Start = entity.StartDate,
                End = entity.EndDate
            };
        }
    }
}
