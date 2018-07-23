using AutoMapper;
using Planet.Common.Helper;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.Web.Models.Products;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Planet.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductCategoryService _categoryService;


        public ProductsController(IProductService productService,
            IProductImageService productImageService,
            IProductCategoryService categoryService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _categoryService = categoryService;
        }

        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return HttpNotFound();

            var productDetail = new ProductDetailViewModel
            {
                Product = Mapper.Map<ProductViewModel>(product),
                Images = Mapper.Map<IEnumerable<ProductImageViewModel>>(_productImageService.GetAll(id)),
            };

            return View(productDetail);
        }

        public ActionResult Category(int id, string keyword = "", int page = 1, string sortBy = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            var products =
                _productService.GetProductsByCategoryId(id, keyword, sortBy, page, pageSize, out int totalItems);

            var pagedResult = new PagedResult<ProductViewModel>
            {
                PageIndex = page,
                PageSize = pageSize,
                Items = Mapper.Map<IEnumerable<ProductViewModel>>(products),
                TotalItems = totalItems,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage"))
            };

            ViewBag.CategoryId = id;

            return View(pagedResult);
        }

        public ActionResult Search(int categoryId, string keyword = "", int page = 1, string sortBy = "new")
        {
            //            if (categoryId.HasValue)
            //            {
            //                return RedirectToAction("Category", "Products", new { id = categoryId, keyword = keyword });
            //            }

            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            var products = _productService.Search(keyword, sortBy, page, pageSize, out int totalItems);

            var pagedResult = new PagedResult<ProductViewModel>
            {
                PageIndex = page,
                PageSize = pageSize,
                Items = Mapper.Map<IEnumerable<ProductViewModel>>(products),
                TotalItems = totalItems,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage"))
            };

            ViewBag.SortBy = sortBy;
            TempData["Keyword"] = keyword;
            TempData["CategoryId"] = categoryId;

            return View(pagedResult);
        }

        public JsonResult GetSuggestedProducts(string keyword)
        {
            var products = _productService.GetSuggestedProductsByKeyWord(keyword);

            return Json(new
            {
                data = Mapper.Map<IEnumerable<ProductSearchViewModel>>(products)
            }, JsonRequestBehavior.AllowGet);
        }


        #region PartialView

        [ChildActionOnly]
        public PartialViewResult _NavbarSearch()
        {
            var treeCategory = GetTreeCategory();

            var selectListCategory = new List<SelectListItem>();
            foreach (var category in treeCategory)
            {
                bool selected = false;
                //                if (TempData["CategoryId"] != null)
                //                {
                //                    selected = category.Id == (int)TempData["CategoryId"];
                //                    if (selected)
                //                    {
                //                        ViewBag.SelectedCategory = category.Name;
                //                    }
                //                }

                selectListCategory.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Name, Selected = selected });
            }

            ViewBag.SelectListCategory = selectListCategory;

            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _NewProducts()
        {
            var products = _productService.GetLastestProducts(MaxItemPerLoad);

            return PartialView(Mapper.Map<IEnumerable<ProductViewModel>>(products));
        }

        [ChildActionOnly]
        public PartialViewResult _BestSellerProducts()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _ProductsGrid()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _RelatedProducts(int id)
        {
            var products = _productService.GetRelatedProducts(id, MaxItemPerLoad);

            return PartialView(Mapper.Map<IEnumerable<ProductViewModel>>(products));
        }

        [ChildActionOnly]
        public PartialViewResult _RecommendedProducts()
        {

            return PartialView();
        }

        #endregion


        #region Helper

        public int MaxItemPerLoad
        {
            get { return int.Parse(ConfigHelper.GetByKey("MaxItemPerLoad")); }
        }

        private IEnumerable<ProductCategoryViewModel> GetTreeCategory()
        {
            var treeResult = new List<ProductCategoryViewModel>();

            var categories = _categoryService.GetParentCategories();
            foreach (var category in categories)
            {
                treeResult.Add(new ProductCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    DisplayOrder = category.DisplayOrder
                });

                GetSubTree(category.Id, 1, treeResult);
            }

            return treeResult;
        }

        private void GetSubTree(int parentId, int level, IList<ProductCategoryViewModel> treeResult)
        {
            var subCategories = _categoryService.GetAllByParentId(parentId);
            foreach (var category in subCategories)
            {
                treeResult.Add(new ProductCategoryViewModel
                {
                    Id = category.Id,
                    Name = HttpContext.Server.HtmlDecode(NameCategoryByLevel(level, category.Name)),
                    DisplayOrder = category.DisplayOrder
                });

                GetSubTree(category.Id, level + 1, treeResult);
            }
        }

        private string NameCategoryByLevel(int level, string name)
        {
            var result = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                result.Append("&nbsp;&nbsp;");
            }

            return result.Append(name).ToString();
        }

        #endregion

    }
}