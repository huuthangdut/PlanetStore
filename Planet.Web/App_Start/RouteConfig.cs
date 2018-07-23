using System.Web.Mvc;
using System.Web.Routing;

namespace Planet.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Login" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "Account", action = "Register" },
                namespaces: new[] { "Planet.Web.Controllers" }
                );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Contact_SendFeedback",
                url: "lien-he/gui-phan-hoi",
                defaults: new { controller = "Contact", action = "SendFeedback" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "checkout",
                defaults: new { controller = "Checkout", action = "AddressAndPayment" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "OrderSuccessed",
                url: "checkout/success/{id}",
                defaults: new { controller = "CheckOut", action = "Complete" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Page",
                url: "p/{alias}",
                defaults: new { controller = "Page", action = "Index" },
                namespaces: new[] { "Planet.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Products", action = "Search" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "ProductCategory",
                url: "{alias}-c{id}",
                defaults: new { controller = "Products", action = "Category" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Products",
                url: "{alias}-p{id}",
                defaults: new { controller = "Products", action = "Details" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "404",
                defaults: new { controller = "Error", action = "NotFound" },
                namespaces: new[] { "Planet.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Planet.Web.Controllers" }
            );




        }
    }
}
