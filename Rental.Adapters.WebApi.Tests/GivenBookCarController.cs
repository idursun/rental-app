using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using Rental.Application;
using Rental.Application.Ports.Repositories;

namespace RentalApp.Adapters.WebApi.Tests
{
    public class GivenBookCarController
    {
        protected TestServer TestServer;
        protected HttpClient HttpClient;
        protected IBookingRepository BookingRepository;
        protected ICarRepository CarRepository;

        [SetUp]
        public void Given()
        {
            BookingRepository = Substitute.For<IBookingRepository>();
            CarRepository = Substitute.For<ICarRepository>();

            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            webHostBuilder.ConfigureTestServices(services =>
            {
                services.AddTransient(c => BookingRepository);
                services.AddTransient(c => CarRepository);
            });

            TestServer = new TestServer(webHostBuilder);
            HttpClient = TestServer.CreateClient();
        }

    }
}
