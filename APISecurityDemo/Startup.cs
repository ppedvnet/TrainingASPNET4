﻿using System;
using System.Security.Claims;
using APISecurityDemo.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(APISecurityDemo.Startup))]

namespace APISecurityDemo
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; } 

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthAuthorizationServerProvider()
                {
                    OnValidateClientAuthentication = async (context) => 
                    {
                        context.Validated();
                    },
                    OnGrantResourceOwnerCredentials = async (context) => 
                    {
                        if (context.UserName == "test@ppedv.de" && 
                            context.Password == "Password1!")
                        {
                            ClaimsIdentity oAuthIdentity =
                                new ClaimsIdentity(context.Options.AuthenticationType);

                            oAuthIdentity.AddClaim(
                                new Claim(ClaimTypes.Role, RoleName.Admin));

                            context.Validated(oAuthIdentity);
                        }
                    }
                },
                AllowInsecureHttp = false,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1)
            };
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
