using CarRental.API.Filters;
using CarRental.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace CarRental.API.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class CarsController : ApiController
    {
        List<Car> cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Name = "Delorian",
                Producer = "DMC",
                Consumption = 123
            },
            new Car
            {
                Id = 2,
                Name = "Mustang",
                Producer = "Ford",
                Consumption = 432
            }
        };

        //[CarExceptionFilter]
        /// <summary>
        /// Super coole Beschreibung
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllCars()
        {
            //try
            //{
                //throw new Exception("Computer says no...");

                return Ok(cars);

            //}
            //catch (Exception ex)
            //{

            //    return new StatusCodeResult(HttpStatusCode.InternalServerError, this);
            //}
        }

        public IHttpActionResult GetCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
            //return new StatusCodeResult(HttpStatusCode.OK, this);
        }

        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // auf db speichern

            return Created(new Uri(Request.RequestUri + "/" + car.Id), car);
        }

        public IHttpActionResult PutCar(int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // ...update

            return Ok();
        }

        public IHttpActionResult DeleteCar(int id)
        {
            var car = cars.SingleOrDefault(c => c.Id == id);
            if (car == null) return NotFound();

            // ...löschen

            return Ok();
        }
    }
}