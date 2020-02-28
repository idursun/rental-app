using System;
using System.Collections.Generic;
using Rental.Domain;

namespace Rental.Application.Ports.Repositories
{
    public interface IBookingRepository
    {
        void BookCar(in Car car, DateTime start, DateTime end, decimal cost);
        List<CarBooking> GetBooking(in Car car, DateTime start, DateTime end);
    }
}
