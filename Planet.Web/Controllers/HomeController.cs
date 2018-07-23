using AutoMapper;
using Planet.Data.Core.Domain;
using Planet.Services.Core;
using Planet.Web.Models;
using Planet.Web.Models.Products;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Planet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IMenuService _menuService;
        private readonly IProductCategoryService _categoryService;
        private readonly ICartService _cartService;

        public HomeController(ISlideService slideService, IMenuService menuService, IProductCategoryService categoryService, ICartService cartService)
        {
            _slideService = slideService;
            _menuService = menuService;
            _categoryService = categoryService;
            _cartService = cartService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _HomeSlider()
        {
            var slide = _slideService.GetSlides();

            return PartialView(Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slide));
        }

        [ChildActionOnly]
        public PartialViewResult _BrandsCarousel()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _HomeDealsAndTabs()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _NavbarMiniCart()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _MainMenu()
        {
            var menu = _menuService.GetParentMenu();

            return PartialView(Mapper.Map<IEnumerable<Menu>>(menu));
        }


        [ChildActionOnly]
        public PartialViewResult _Header()
        {
            // TODO: fix speed issues 
            var parentCategories = _categoryService.GetParentCategories();
            var parentCategoriesViewModel = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(parentCategories);

            foreach (var category in parentCategoriesViewModel)
            {
                category.Chidlren = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(_categoryService.GetChildrenLevelOneByParentId(category.Id));

            }

            return PartialView(parentCategoriesViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public PartialViewResult _Footer()
        {
            return PartialView();
        }
    }
}