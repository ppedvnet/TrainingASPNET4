using APISecurityDemo.App_Start;
using APISecurityDemo.Filters;
using System.Web.Http;

namespace APISecurityDemo.Controllers
{
   // [RequireCoolHttpsAttribute]
    [Authorize(Roles = RoleName.Student)]
    public class BikeController : ApiController
    {
        public IHttpActionResult GetAllBikes()
        {
            return Ok("Sie sind eingeloggt!");
        }
    }
}
