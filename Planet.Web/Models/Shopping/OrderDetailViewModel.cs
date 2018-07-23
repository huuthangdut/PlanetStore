using Planet.Web.Models.Products;

namespace Planet.Web.Models.Shopping
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderViewModel Order { get; set; }

        public ProductViewModel Product { get; set; }
    }
}