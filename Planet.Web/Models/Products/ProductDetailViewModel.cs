using System.Collections.Generic;

namespace Planet.Web.Models.Products
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }

        public IEnumerable<ProductImageViewModel> Images { get; set; }
    }
}