namespace Rental.Domain
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public Price Price { get; set; }
        public Branch  Branch { get; set; }
    }
}
