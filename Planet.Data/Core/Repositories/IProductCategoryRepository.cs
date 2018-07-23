using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Data.Core.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetAllByAlias(string alias);
    }
}
