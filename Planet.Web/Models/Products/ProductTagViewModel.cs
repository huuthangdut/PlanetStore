namespace Planet.Web.Models.Products
{
    public class ProductTagViewModel
    {
        public int ProductId { set; get; }

        public string TagId { set; get; }

        public virtual ProductViewModel Product { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}