using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
