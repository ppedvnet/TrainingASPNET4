using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CarRental.Filters;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        [Log]
        public ActionResult Index()
        {
            var car = new Car
            {
                Id = 1,
                CarName = "Delorian",
                CarProducer = "DMC",
                YearOfConstruction = new DateTime(1985, 1, 1),
                Consumption = 10.12,
                CarType = CarType.Limosine
            };

            var car2 = new Car
            {
                Id = 2,
                CarName = "Mustang",
                CarProducer = "Ford",
                YearOfConstruction = new DateTime(1968, 1, 1),
                Consumption = 33.44,
                CarType = CarType.Kompakt
            };

            var cars = new List<Car>();
            cars.Add(car);
            cars.Add(car2);

            List<CarVm> carsVm = Mapper.Map<List<CarVm>>(cars);

            ViewBag.ASDF = "Nürnberg";

            return View(carsVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarVm carVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carVm);
            }

            // mapping carVm => car
            // Daten auf DB speichern

            return View();
        }

        public ActionResult GetMoreCars()
        {
            var cars = new List<CarVm>
            {
                new CarVm
                {
                    Name = "Golf",
                    CarType = CarType.Kompakt,
                    Producer = "VW"
                },
                new CarVm
                {
                    Name = "Manta",
                    CarType = CarType.Van,
                    Producer = "Opel"
                }
            };
            return PartialView("_CarsTableResult", cars);
        }

        public ActionResult RazorDemo()
        {
            // ViewBag, ViewData, ViewModel
            var c = new CarVm { Name = "Delorian" };

            ViewData["Auto"] = c;
            ViewBag.Auto = c;

            // Cookies
            var keks = new HttpCookie("keks");
            keks.Value = "Hallo Nürnberg";
            keks.Expires = DateTime.Now.AddHours(1);

            //Response.Cookies.Add(keks);
            //Löschen expires in Vergangenheit setzen
            //Response.Cookies["keks"].Expires = DateTime.Now.AddDays(-1);
            string xyz;
            if(Request.Cookies["keks"] != null)
                xyz = Request.Cookies["keks"].Value;

            Session["Autos"] = c;
            var cool = Session["Autos"] as CarVm;

            return View();
        }
    }
}