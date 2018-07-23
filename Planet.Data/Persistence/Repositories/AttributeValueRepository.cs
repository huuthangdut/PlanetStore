using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class AttributeValueRepository : RepositoryBase<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
