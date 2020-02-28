using System;
using Rental.Application.Ports.Repositories;
using Rental.Domain.Exceptions;

namespace Rental.Application.UseCases
{
    public class BookCarUseCase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookCarUseCase(ICarRepository carRepository, IBookingRepository bookingRepository)
        {
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
        }

        public void Book(int carId, DateTime start, DateTime end)
        {
            var car = _carRepository.FindById(carId);
            if (car == null)
            {
                throw new CarDoesNotExistsException(carId);
            }

            var bookings = _bookingRepository.GetBooking(car, start, end);
            if (bookings.Count > 0)
            {
                throw new CarIsAlreadyBookedException(carId, start, end);
            }

            var days = (int)Math.Ceiling((end - start).TotalDays);
            _bookingRepository.BookCar(car, start, end, car.Price.DailyPrice * days);
        }
    }
}
