using Newtonsoft.Json;
using Planet.WebApi.Common;
using Planet.WebApi.Dtos.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Planet.WebApi.Infrastructure.Attribute
{
    // Authorize Attribute for API Controller
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string Action;
        public string Function;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (principal != null && !principal.Identity.IsAuthenticated)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                var roles = JsonConvert.DeserializeObject<List<string>>(principal?.FindFirst("roles").Value);
                if (roles.Any())
                {
                    if (!roles.Contains(RoleName.Admin))
                    {
                        var permissions =
                            JsonConvert.DeserializeObject<List<PermissionDto>>(principal?.FindFirst("permissions")
                                .Value);

                        if ((Action == ActionName.CanCreate && !permissions.Exists(p => p.FunctionId == Function && p.CanCreate))
                            || (Action == ActionName.CanRead && !permissions.Exists(p => p.FunctionId == Function && p.CanRead))
                            || (Action == ActionName.CanUpdate && !permissions.Exists(p => p.FunctionId == Function && p.CanUpdate))
                            || (Action == ActionName.CanDelete && !permissions.Exists(p => p.FunctionId == Function && p.CanDelete)))
                        {
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        }
                    }
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                }

            }
        }
    }
}