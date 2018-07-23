using System.Collections.Generic;

namespace Planet.Web.Models.Shopping
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartItemViewModel> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public int CartQuantity { get; set; }
    }
}