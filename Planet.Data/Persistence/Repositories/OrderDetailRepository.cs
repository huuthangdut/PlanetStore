using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }


}
