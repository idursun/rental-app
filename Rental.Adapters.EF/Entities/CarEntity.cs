using System;
using System.ComponentModel.DataAnnotations.Schema;
using Rental.Domain;

namespace Rental.Adapters.EF.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public Currency Currency { get; set; }
    }

    public static class CarEntityExtension
    {
        public static Car ToDomain(this CarEntity entity)
        {
            return new Car
            {
                Branch = new Branch(),
                Model = entity.Model,
                Price = new Price
                {
                    Currency = entity.Currency,
                    DailyPrice = entity.PricePerDay
                }
            };
        }
    }
}
