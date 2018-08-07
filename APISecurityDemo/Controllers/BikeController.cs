using APISecurityDemo.Filters;
using System.Web.Http;

namespace APISecurityDemo.Controllers
{
   // [RequireCoolHttpsAttribute]
    public class BikeController : ApiController
    {
        public IHttpActionResult GetAllBikes()
        {
            return Ok("Sie sind eingeloggt!");
        }
    }
}