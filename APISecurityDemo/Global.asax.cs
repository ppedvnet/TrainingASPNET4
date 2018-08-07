using APISecurityDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace APISecurityDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new RequireCoolHttpsAttributeAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
