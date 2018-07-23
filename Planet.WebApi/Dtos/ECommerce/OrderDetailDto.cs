namespace Planet.WebApi.Dtos.ECommerce
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Attributes { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual OrderDto Order { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}