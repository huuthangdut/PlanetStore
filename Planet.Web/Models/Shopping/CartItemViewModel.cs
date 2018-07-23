using System;
using Planet.Data.Core.Domain;

namespace Planet.Web.Models.Shopping
{
    public class CartItemViewModel
    {
        public int Id { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }

        public string Attributes { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public Product Product { get; set; }
    }
}