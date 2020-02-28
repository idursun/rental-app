using System;
using System.Collections.Generic;
using System.Linq;
using Rental.Adapters.EF.Entities;
using Rental.Application.Ports.Repositories;
using Rental.Domain;

namespace Rental.Adapters.EF.Repositories
{
    public class BookingRepositoryAdapter : IBookingRepository
    {
        private readonly RentalDbContext _dbContext;

        public BookingRepositoryAdapter(RentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BookCar(in Car car, DateTime start, DateTime end, decimal cost)
        {
            var bookingEntity = new CarBookingEntity
            {
                CarId = 1, //TODO find car id
                StartDate = start,
                EndDate = end
            };

            _dbContext.Bookings.Add(bookingEntity);
            _dbContext.SaveChanges();
        }

        public List<CarBooking> GetBooking(in Car car, DateTime start, DateTime end)
        {
            return _dbContext.Bookings
                .Where(x => x.StartDate >= start && x.EndDate <= end)
                .Select(x => x.ToDomain())
                .ToList();
        }
    }
}
