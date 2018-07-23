using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
