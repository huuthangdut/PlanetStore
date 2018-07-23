using System.Collections.Generic;
using System.Linq;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;

namespace Planet.Data.Persistence.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from post in DbContext.Posts
                        join postTag in DbContext.PostTags on post.Id equals postTag.PostId
                        where postTag.TagId == tagId
                        select post;

            totalRow = query.Count();

            return query.OrderByDescending(p => p.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
