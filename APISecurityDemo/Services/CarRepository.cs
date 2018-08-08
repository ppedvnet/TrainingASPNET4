using System.Collections.Generic;
using APISecurityDemo.Models;

namespace APISecurityDemo.Services
{
    public class CarRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetAll()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Name = "Delorian",
                    Brand = "DMC"
                },
                new Car
                {
                    Id = 2,
                    Name = "Mustang",
                    Brand = "Ford"
                }
            };
        }
    }

    public class BusRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetAll()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Name = "Transporter",
                    Brand = "VW"
                }
            };
        }
    }
}