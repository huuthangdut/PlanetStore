using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.WebApi.Common;
using Planet.WebApi.Dtos.Auth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Planet.WebApi.Infrastructure.Providers
{
    public class AppAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public AppAuthorizationServerProvider()
        {
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            await Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<UserManager<AppUser>>();
            AppUser user;
            try
            {
                user = await userManager.FindAsync(context.UserName, context.Password);
            }
            catch
            {
                // Could not retrieve the user due to error.
                context.SetError("server_error", ApiMessage.ServerError);
                context.Rejected();
                return;
            }
            if (user != null)
            {
                var permissions = ServiceFactory.Get<IPermissionService>().GetPermissionsByUserId(user.Id);
                var permissionViewModels = Mapper.Map<IEnumerable<PermissionDto>>(permissions);
                var roles = userManager.GetRoles(user.Id);
                ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);

                identity.AddClaim(new Claim("firstName", user.FirstName ?? ""));
                identity.AddClaim(new Claim("lastName", user.LastName ?? ""));
                identity.AddClaim(new Claim("avatar", user.Avatar ?? ""));
                identity.AddClaim(new Claim("email", user.Email));
                identity.AddClaim(new Claim("userName", user.UserName));
                identity.AddClaim(new Claim("roles", JsonConvert.SerializeObject(roles)));
                identity.AddClaim(new Claim("permissions", JsonConvert.SerializeObject(permissionViewModels)));


                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    ["firstName"] = user.FirstName ?? "",
                    ["lastName"] = user.LastName ?? "",
                    ["avatar"] = user.Avatar ?? "",
                    ["email"] = user.Email,
                    ["userName"] = user.UserName,
                    ["permissions"] = JsonConvert.SerializeObject(permissionViewModels),
                    ["roles"] = JsonConvert.SerializeObject(roles)

                });
                context.Validated(new AuthenticationTicket(identity, props));
            }
            else
            {
                context.SetError("invalid_grant", ApiMessage.InvalidLogin);
                context.Rejected();
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

    }
}