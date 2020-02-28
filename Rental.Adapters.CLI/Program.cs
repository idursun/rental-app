using System;
using Microsoft.Data.SqlClient;
using Rental.Adapters.EF;
using Rental.Adapters.EF.Repositories;
using Rental.Application.UseCases;
using Rental.Domain.Exceptions;

namespace Rental.Adapters.CLI
{
    class Program
    {
        static int Main(int carId, DateTime startDate, DateTime endDate)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "Rental",
                IntegratedSecurity = true
            };

            using var rentalDbContext = new RentalDbContext(connectionStringBuilder.ToString());

            try
            {
                var useCase = new BookCarUseCase(new CarRepositoryAdapter(rentalDbContext), new BookingRepositoryAdapter(rentalDbContext));
                useCase.Book(carId, startDate, endDate);
            }
            catch (CarDoesNotExistsException e)
            {
                Console.Error.WriteLine($"Car is not found: {carId}");
                return 1;
            }

            return 0;
        }
    }
}
