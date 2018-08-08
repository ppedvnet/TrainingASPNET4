using System.Collections.Generic;
using APISecurityDemo.Models;

namespace APISecurityDemo.Services
{
    public class BikeRepository : IRepository<Bike>
    {
        public IEnumerable<Bike> GetAll()
        {
            return new List<Bike>
            {
                new Bike
                {
                    Id = 1,
                    Name = "KTM",
                    Consumption = 123
                }
            };
        }
    }
}