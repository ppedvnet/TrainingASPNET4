using System;

namespace EfCodeFirstDemo.Models
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}