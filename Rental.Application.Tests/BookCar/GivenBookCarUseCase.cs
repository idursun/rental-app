using NSubstitute;
using NUnit.Framework;
using Rental.Application;
using Rental.Application.Ports.Repositories;
using Rental.Application.UseCases;

namespace RentalApp.Application.Tests.BookCar
{
    public class GivenBookCarUseCase
    {
        protected BookCarUseCase BookCarUseCase;
        protected IBookingRepository BookingRepository;
        protected ICarRepository CarRepository;

        [SetUp]
        public void Given()
        {
            BookingRepository = Substitute.For<IBookingRepository>();
            CarRepository = Substitute.For<ICarRepository>();
            BookCarUseCase = new BookCarUseCase(CarRepository, BookingRepository);
        }
    }
}
