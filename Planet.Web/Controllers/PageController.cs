using System.Web.Mvc;
using AutoMapper;
using Planet.Data.Core.Domain;
using Planet.Services.Core;
using Planet.Web.Models;

namespace Planet.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            var model = Mapper.Map<Page, PageViewModel>(page);

            return View(model);
        }
    }
}