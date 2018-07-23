using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Planet.Data.Persistence.Repositories
{
    public class FunctionRepository : RepositoryBase<Function>, IFunctionRepository
    {
        public FunctionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Function> GetFunctionsByUserId(string userId)
        {
            //TODO: rewrite this function
            var query = (from f in DbContext.Functions
                         join p in DbContext.Permissions on f.Id equals p.FunctionId
                         join r in DbContext.Roles on p.RoleId equals r.Id
                         join ur in DbContext.AppUserRoles on r.Id equals ur.RoleId
                         join u in DbContext.Users on ur.UserId equals u.Id
                         where u.Id == userId && p.CanRead
                         select f);
            var parentIds = query.Select(f => f.ParentId).Distinct();
            query = query.Union(DbContext.Functions.Where(f => parentIds.Contains(f.Id)));

            return query.ToList();
        }
    }
}
