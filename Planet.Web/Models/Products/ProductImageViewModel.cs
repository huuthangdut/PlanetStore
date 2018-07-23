namespace Planet.Web.Models.Products
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }

        public string Type { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}