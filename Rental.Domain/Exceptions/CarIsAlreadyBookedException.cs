using System;

namespace Rental.Domain.Exceptions
{
    public class CarIsAlreadyBookedException : Exception
    {
        public CarIsAlreadyBookedException(int carId, in DateTime start, in DateTime end)
        {
        }
    }
}
