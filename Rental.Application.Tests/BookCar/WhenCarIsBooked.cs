using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Rental.Domain;

namespace RentalApp.Application.Tests.BookCar
{
    public class WhenCarIsBooked : GivenBookCarUseCase
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
            BookingRepository.GetBooking(car, _startDate, _endDate).Returns(new List<CarBooking>());
            BookCarUseCase.Book(0, _startDate, _endDate);
        }

        [Test]
        public void should_check_if_there_are_any_booking_within_start_and_end_dates()
        {
            BookingRepository.Received().GetBooking(car, _startDate, _endDate);
        }

        [Test]
        public void should_place_a_booking_with_cost()
        {
            BookingRepository.Received().BookCar(car, _startDate, _endDate, Arg.Any<decimal>());
        }

    }
}
