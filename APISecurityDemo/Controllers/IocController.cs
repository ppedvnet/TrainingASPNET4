using APISecurityDemo.Models;
using APISecurityDemo.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace APISecurityDemo.Controllers
{
    public class IocController : ApiController
    {
        //private readonly IRepository<Car> _repo = new CarRepository();
        private readonly IRepository<Car> _repo;
        private readonly IRepository<Bike> _brepo;

        public IocController(IRepository<Car> repo, IRepository<Bike> brepo)
        {
            if (repo == null) throw new ArgumentNullException("Repo is empty");
            _repo = repo;

            if (brepo == null) throw new ArgumentNullException("Repo is empty");
            _brepo = brepo;
        }

        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}