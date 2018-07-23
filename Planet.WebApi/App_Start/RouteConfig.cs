using System.Web.Mvc;
using System.Web.Routing;

namespace Planet.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Help", action = "Index" },
                namespaces: new[] { "Planet.WebApi.Areas.HelpPage.Controllers" }
            ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}
