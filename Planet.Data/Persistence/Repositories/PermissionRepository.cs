using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Planet.Data.Persistence.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Permission> GetByUserId(string userId)
        {
            var query = from f in DbContext.Functions
                        join p in DbContext.Permissions on f.Id equals p.FunctionId
                        join r in DbContext.Roles on p.RoleId equals r.Id
                        join ur in DbContext.AppUserRoles on r.Id equals ur.RoleId
                        join u in DbContext.Users on ur.UserId equals u.Id
                        where u.Id == userId
                        select p;
            return query.ToList();
        }
    }
}
