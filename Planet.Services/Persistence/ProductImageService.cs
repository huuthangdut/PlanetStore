using System.Collections.Generic;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public ProductImage Add(ProductImage productImage)
        {
            return _productImageRepository.Add(productImage);
        }

        public void Delete(int id)
        {
            _productImageRepository.Delete(id);
        }

        public void DeleteAllImagesOfProduct(int productId)
        {
            _productImageRepository.Delete(i => i.ProductId == productId);
        }

        public IEnumerable<ProductImage> GetAll(int productId)
        {
            return _productImageRepository.Filter(p => p.ProductId == productId);
        }
    }
}
