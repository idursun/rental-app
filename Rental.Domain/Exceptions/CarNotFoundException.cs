using System;

namespace Rental.Domain.Exceptions
{
    public class CarDoesNotExistsException : Exception
    {
        public int CarId { get; }

        public CarDoesNotExistsException(int carId)
        {
            CarId = carId;
        }
    }
}
