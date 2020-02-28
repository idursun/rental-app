using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Rental.Domain;
using Rental.Domain.Exceptions;

namespace RentalApp.Application.Tests.BookCar
{
    public class WhenCarIsAlreadyBooked : GivenBookCarUseCase
    {
        private Car car;
        private DateTime _startDate;
        private DateTime _endDate;

        [SetUp]
        public void SetUp()
        {
            _startDate = DateTime.UtcNow.Date;
            _endDate = DateTime.UtcNow.Date.AddDays(2);

            car = new Car
            {
                Price = new Price {DailyPrice = 100}
            };

            CarRepository.FindById(0).Returns(car);
            BookingRepository.GetBooking(car, _startDate, _endDate).Returns(new List<CarBooking> {new CarBooking()});
        }

        [Test]
        public void it_should_throw_exception()
        {
            Assert.Throws<CarIsAlreadyBookedException>(() => BookCarUseCase.Book(0, _startDate, _endDate));
        }
    }
}
