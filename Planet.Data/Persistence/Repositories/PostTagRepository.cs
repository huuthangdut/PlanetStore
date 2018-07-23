using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }


}
