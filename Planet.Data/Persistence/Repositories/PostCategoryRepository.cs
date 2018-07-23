using System.Collections.Generic;
using System.Linq;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<PostCategory> GetAllByAlias(string alias)
        {
            return this.DbContext.PostCategories.Where(pc => pc.Alias.Equals(alias));
        }
    }
}
