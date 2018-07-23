using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Services.Core
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory category);
        void Update(ProductCategory category);
        ProductCategory Delete(int id);
        IEnumerable<ProductCategory> GetAll(string keyword = null);
        IEnumerable<ProductCategory> GetAllWithPaging(int pageIndex, int pageSize, out int totalItems, string keyword = null);
        IEnumerable<ProductCategory> GetAllByParentId(int parentId);
        IEnumerable<ProductCategory> GetParentCategories();
        IEnumerable<ProductCategory> GetChildrenLevelOneByParentId(int id);
        ProductCategory GetById(int id);
    }
}
