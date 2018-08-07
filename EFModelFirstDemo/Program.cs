using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ModelFirstDemoDBContainer())
            {
                Console.WriteLine("Namen des Studenten:");

                var firstName = Console.ReadLine();
                var student = new Student
                {
                    FirstName = firstName,
                    LastName = "Student"
                };

                db.Students.Add(student);
                db.SaveChanges();

                var query = from d in db.Students
                            orderby d.FirstName
                            select d;

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                }

                Console.ReadKey();
            }
        }
    }
}
