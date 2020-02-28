using System.Collections.Generic;
using System.Linq;
using Rental.Adapters.EF.Entities;
using Rental.Application.Ports.Repositories;
using Rental.Domain;

namespace Rental.Adapters.EF.Repositories
{
    public class CarRepositoryAdapter : ICarRepository
    {
        private readonly RentalDbContext _rentalDbContext;

        public CarRepositoryAdapter(RentalDbContext rentalDbContext)
        {
            _rentalDbContext = rentalDbContext;
        }

        public Car FindById(int id)
        {
            var car = _rentalDbContext.Cars.Find(id);
            return car?.ToDomain();
        }

        public List<Car> FindByYear(int year)
        {
            return _rentalDbContext.Cars.ToList()
                .Select(x => x.ToDomain())
                .ToList();
        }
    }
}
