using System.Collections.Generic;
using System.Linq;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetAllByAlias(string alias)
        {
            return DbContext.ProductCategories.Where(pc => pc.Alias.Equals(alias));
        }
    }
}
