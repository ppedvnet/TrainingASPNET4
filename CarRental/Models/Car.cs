using System;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarProducer { get; set; }
        public DateTime? YearOfConstruction { get; set; }
        public double? Consumption { get; set; }
        public CarType CarType { get; set; } = CarType.Kompakt;
    }

    public enum CarType
    {
        Kompakt,
        Limosine,
        Van
    }
}