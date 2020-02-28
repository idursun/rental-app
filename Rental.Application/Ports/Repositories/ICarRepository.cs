using System.Collections.Generic;
using Rental.Domain;

namespace Rental.Application.Ports.Repositories
{
    public interface ICarRepository
    {
        Car FindById(int id);
        List<Car> FindByYear(int year);
    }
}
