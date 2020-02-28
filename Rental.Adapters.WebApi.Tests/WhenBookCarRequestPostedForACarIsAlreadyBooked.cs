using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rental.Domain;
using RentalApp.Adapters.WebApi.Models;
using Shouldly;

namespace RentalApp.Adapters.WebApi.Tests
{
    public class WhenBookCarRequestPostedForACarIsAlreadyBooked : GivenBookCarController
    {
        private HttpResponseMessage _message;

        [SetUp]
        public async Task SetUp()
        {
            var request = new BookCarRequest
            {
                CarId = 1,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(5)
            };

            var car = new Car();
            CarRepository.FindById(1).Returns(car);
            BookingRepository.GetBooking(car, Arg.Any<DateTime>(), Arg.Any<DateTime>())
                .Returns(new List<CarBooking> {new CarBooking()});
            _message = await HttpClient.PostAsJsonAsync("/booking", request);
        }

        [Test]
        public void it_should_return_badrequest()
        {
            _message.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}
