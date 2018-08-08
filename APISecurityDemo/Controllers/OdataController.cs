using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using APISecurityDemo.Models;

namespace APISecurityDemo.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using APISecurityDemo.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Car>("Odata");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OdataController : ODataController
    {
        private CarsDbContext db = new CarsDbContext();

        // GET: odata/Odata
        [Queryable]
        public IQueryable<Car> GetOdata()
        {
            return db.Cars;
        }

        // GET: odata/Odata(5)
        //[Queryable]
        //public SingleResult<Car> GetCar([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.Cars.Where(car => car.Id == key));
        //}

        // PUT: odata/Odata(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Car> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Car car = await db.Cars.FindAsync(key);
            if (car == null)
            {
                return NotFound();
            }

            patch.Put(car);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(car);
        }

        // POST: odata/Odata
        public async Task<IHttpActionResult> Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            await db.SaveChangesAsync();

            return Created(car);
        }

        // PATCH: odata/Odata(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Car> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Car car = await db.Cars.FindAsync(key);
            if (car == null)
            {
                return NotFound();
            }

            patch.Patch(car);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(car);
        }

        // DELETE: odata/Odata(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Car car = await db.Cars.FindAsync(key);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int key)
        {
            return db.Cars.Count(e => e.Id == key) > 0;
        }
    }
}
