using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using APISecurityDemo.Filters;
using APISecurityDemo.Models;
using APISecurityDemo.Services;

namespace APISecurityDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new RequireCoolHttpsAttributeAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            // IoC
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.Register(c => new CarsDbContext()).InstancePerRequest();

            builder.RegisterType<BusRepository>()
                .As<IRepository<Car>>().InstancePerRequest();
            builder.RegisterType<BikeRepository>()
                .As<IRepository<Bike>>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }
    }
}
