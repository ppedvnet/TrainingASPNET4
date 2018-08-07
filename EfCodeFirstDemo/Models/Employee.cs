using System.Collections.Generic;

namespace EfCodeFirstDemo.Models
{
    public class Employee : Person
    {
        public string Occupation { get; set; }

        public virtual HashSet<Client> Clients { get; set; } = new HashSet<Client>();
        public virtual HashSet<Department> Departments { get; set; } = new HashSet<Department>();
    }
}