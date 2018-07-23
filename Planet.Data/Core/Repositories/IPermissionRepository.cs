using System.Collections.Generic;
using Permission = Planet.Data.Core.Domain.Permission;

namespace Planet.Data.Core.Repositories
{
    public interface IPermissionRepository : IRepository<Domain.Permission>
    {
        List<Permission> GetByUserId(string userId);
    }
}
