using System.Collections.Generic;
using System.Linq;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetAllByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from product in DbContext.Products
                        join productTag in DbContext.ProductTags on product.Id equals productTag.ProductId
                        where productTag.TagId == tagId
                        select product;

            totalRow = query.Count();

            return query.OrderByDescending(p => p.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
