namespace Planet.WebApi.Dtos.ECommerce
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }

        public int Type { get; set; }
    }
}