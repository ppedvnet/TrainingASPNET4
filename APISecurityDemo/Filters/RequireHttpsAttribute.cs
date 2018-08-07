using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace APISecurityDemo.Filters
{
    public class RequireCoolHttpsAttributeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext ctx)
        {
            if (ctx.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                ctx.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Erforderlich"
                };
            }
            else
            {
                base.OnAuthorization(ctx);
            }
        }
    }
}