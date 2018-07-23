using System.Web.Mvc;

namespace Planet.Web.Controllers
{
    public class PostsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            return PartialView("Posts/_Categories");
        }

        [ChildActionOnly]
        public ActionResult PopularTags()
        {
            return PartialView("Posts/_PopularTags");
        }

        [ChildActionOnly]
        public PartialViewResult Blog()
        {
            return PartialView("Posts/_Blog");
        }
    }
}