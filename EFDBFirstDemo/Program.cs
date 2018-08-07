using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ModelFirstDemoDBEntities())
            {
                Console.WriteLine("Kurs name eingeben:");
                var cname = Console.ReadLine();
                var kurs = new Courses {
                    Title = cname
                };
                db.Courses.Add(kurs);
                db.SaveChanges();

                var query = from c in db.Courses
                            orderby c.Title
                            select c;

                Console.WriteLine("Alle Kurse in DB");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Title);
                }
                Console.ReadKey();
            }
        }
    }
}
