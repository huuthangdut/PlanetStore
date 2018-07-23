using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Services.Core
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll(string keyword = "");
        IEnumerable<Product> GetAll(int pageIndex, int pageSize, out int totalItems, string keyword = "");
        IEnumerable<Product> GetLastestProducts(int top);
        IEnumerable<Product> GetSaleProducts(int top);
        IEnumerable<Product> GetHotProducts(int top);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId, string keyword, string sortBy, int pageIndex, int pageSize, out int totalItems);
        IEnumerable<Product> Search(string keyword, string sortBy, int pageIndex, int pageSize, out int totalItems);
        IEnumerable<Product> GetRelatedProducts(int productId, int top);
        IEnumerable<Product> GetSuggestedProductsByKeyWord(string name);

    }
}
