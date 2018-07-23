using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Data.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tagId, int page, int pageSize, out int totalRow);
    }
}
