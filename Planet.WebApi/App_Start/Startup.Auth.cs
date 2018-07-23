using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Planet.Data.Core.Domain;
using Planet.Data.Persistence;
using Planet.Infrastructure.Identity;
using Planet.WebApi;
using Planet.WebApi.Infrastructure.Providers;
using System;

[assembly: OwinStartup(typeof(Startup))]

namespace Planet.WebApi
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(PlanetContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            app.CreatePerOwinContext<UserManager<AppUser>>(CreateManager);


            //Allow Cross origin for API
            app.UseCors(CorsOptions.AllowAll);


            // Configure the sign in token
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/oauth/token"),
                Provider = new AppAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            });

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                map.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
                {
                    Provider = new QueryStringOAuthBearerProvider()
                });

                var hubConfiguration = new HubConfiguration
                {
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    EnableJSONP = true,
                    EnableDetailedErrors = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                map.RunSignalR(hubConfiguration);
            });


        }

        private static UserManager<AppUser> CreateManager(IdentityFactoryOptions<UserManager<AppUser>> options, IOwinContext context)
        {
            var userStore = new UserStore<AppUser>(context.Get<PlanetContext>());
            var owinManager = new UserManager<AppUser>(userStore);

            return owinManager;
        }
    }
}
