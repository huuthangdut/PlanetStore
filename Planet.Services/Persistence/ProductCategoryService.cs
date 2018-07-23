using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planet.Services.Persistence
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;

        public ProductCategoryService(IProductCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ProductCategory Add(ProductCategory category)
        {
            category.DateCreated = DateTime.Now;
            return _categoryRepository.Add(category);
        }

        public ProductCategory GetById(int id)
        {
            return _categoryRepository.Find(id);
        }

        public void Update(ProductCategory category)
        {
            category.DateUpdated = DateTime.Now;
            _categoryRepository.Update(category);
        }

        public ProductCategory Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword = null)
        {
            return keyword == null
                ? _categoryRepository.Filter(null, c => c.DateCreated, ListSortDirection.Descending)
                : _categoryRepository.Filter(c => c.Name.Contains(keyword) || c.Description.Contains(keyword), c => c.DateCreated, ListSortDirection.Descending);
        }

        public IEnumerable<ProductCategory> GetAllWithPaging(int pageIndex, int pageSize, out int totalItems, string keyword = null)
        {
            return keyword == null
                ? _categoryRepository.Filter(null, p => p.DateCreated, ListSortDirection.Descending, out totalItems, pageIndex, pageSize)
                : _categoryRepository.Filter(p => p.Name.Contains(keyword) || p.Description.Contains(keyword), p => p.DateCreated, ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _categoryRepository.Filter(c => c.ParentId == parentId);
        }

        public IEnumerable<ProductCategory> GetParentCategories()
        {
            return _categoryRepository.Filter(c => c.ParentId == null);
        }

        public IEnumerable<ProductCategory> GetChildrenLevelOneByParentId(int id)
        {
            return _categoryRepository.Filter(c => c.ParentId == id);
        }
    }
}
