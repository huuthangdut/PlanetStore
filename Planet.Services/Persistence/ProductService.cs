using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Planet.Services.Persistence
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int id)
        {
            return _productRepository.Find(p => p.Id == id, "ProductCategory");
        }

        public Product Add(Product product)
        {
            product.DateCreated = DateTime.Now;
            return _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            product.DateUpdated = DateTime.Now;
            _productRepository.Update(product);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll(string keyword = "")
        {
            return _productRepository.Filter(p => p.Name.Contains(keyword) || p.Description.Contains(keyword), p => p.DateCreated, ListSortDirection.Descending, "ProductCategory");
        }

        public IEnumerable<Product> GetAll(int pageIndex, int pageSize, out int totalItems, string keyword = "")
        {
            return _productRepository.Filter(p => p.Name.Contains(keyword) || p.Description.Contains(keyword),
                                            p => p.DateCreated, ListSortDirection.Ascending, out totalItems, pageIndex, pageSize, "ProductCategory");
        }

        public IEnumerable<Product> GetLastestProducts(int top)
        {
            var lastestProducts = _productRepository.Filter(null, p => p.DateCreated, ListSortDirection.Descending, "ProductCategory").ToList();
            return top > lastestProducts.Count ? lastestProducts : lastestProducts.Take(top);
        }

        public IEnumerable<Product> GetSaleProducts(int top)
        {
            var saleProducts = _productRepository.Filter(p => p.PromotionPrice.HasValue, p => p.PromotionPrice,
                ListSortDirection.Descending, "ProductCategory").ToList();

            return top > saleProducts.Count ? saleProducts : saleProducts.Take(top);
        }

        public IEnumerable<Product> GetHotProducts(int top)
        {
            var hotProducts = _productRepository.Filter(p => p.HotFlag == true, p => p.DateCreated, ListSortDirection.Descending, "ProductCategor").ToList();
            return top > hotProducts.Count ? hotProducts : hotProducts.Take(top);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId, string keyword, string sortBy, int pageIndex, int pageSize, out int totalItems)
        {
            switch (sortBy)
            {
                case "new":
                    return _productRepository.Filter(p => p.CategoryId == categoryId && p.Name.Contains(keyword), p => p.DateCreated,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "popular":
                    return _productRepository.Filter(p => p.CategoryId == categoryId && p.Name.Contains(keyword), p => p.ViewCount,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "discount":
                    return _productRepository.Filter(p => p.CategoryId == categoryId && p.PromotionPrice.HasValue && p.Name.Contains(keyword), p => p.PromotionPrice.Value,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "price":
                default:
                    return _productRepository.Filter(p => p.CategoryId == categoryId && p.Name.Contains(keyword), p => p.UnitPrice,
                        ListSortDirection.Ascending, out totalItems, pageIndex, pageSize);

            }
        }

        public IEnumerable<Product> Search(string keyword, string sortBy, int pageIndex, int pageSize, out int totalItems)
        {
            switch (sortBy)
            {
                case "new":
                    return _productRepository.Filter(p => p.Name.Contains(keyword), p => p.DateCreated,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "popular":
                    return _productRepository.Filter(p => p.Name.Contains(keyword), p => p.ViewCount,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "discount":
                    return _productRepository.Filter(p => p.PromotionPrice.HasValue && p.Name.Contains(keyword), p => p.PromotionPrice.Value,
                        ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
                case "price":
                default:
                    return _productRepository.Filter(p => p.Name.Contains(keyword), p => p.UnitPrice,
                        ListSortDirection.Ascending, out totalItems, pageIndex, pageSize);

            }
        }

        public IEnumerable<Product> GetRelatedProducts(int productId, int top)
        {
            var product = _productRepository.Find(p => p.Id == productId);
            var relatedProducts = _productRepository.Filter(p => p.Id != productId && p.CategoryId == product.CategoryId, "ProductCategory").ToList();

            return top > relatedProducts.Count ? relatedProducts : relatedProducts.Take(top);
        }


        public IEnumerable<Product> GetSuggestedProductsByKeyWord(string name)
        {
            const int top = 5;
            var suggestedProducts = _productRepository
                .Filter(p => p.Name.ToLower().Contains(name.ToLower()), p => p.Name, ListSortDirection.Ascending, "ProductCategory").ToList();

            return top > suggestedProducts.Count ? suggestedProducts : suggestedProducts.Take(top);
        }
    }


}
