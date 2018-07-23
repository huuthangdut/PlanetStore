using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Data.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllByTag(string tagId, int page, int pageSize, out int totalRow);
    }
}
