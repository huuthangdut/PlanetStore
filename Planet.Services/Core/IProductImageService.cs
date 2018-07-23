using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IProductImageService
    {
        ProductImage Add(ProductImage productImage);
        void Delete(int id);
        void DeleteAllImagesOfProduct(int productId);
        IEnumerable<ProductImage> GetAll(int productId);
    }
}
