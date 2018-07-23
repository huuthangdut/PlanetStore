using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Data.Core.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        IEnumerable<PostCategory> GetAllByAlias(string alias);
    }
}
