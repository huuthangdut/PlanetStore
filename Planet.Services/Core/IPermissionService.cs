using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IPermissionService
    {
        Permission Get(string roleId, string functionId);
        IEnumerable<Permission> GetAll();
        IEnumerable<Permission> GetPermissionsByFunctionId(string functionId);
        IEnumerable<Permission> GetPermissionsByRoleId(string roleId);
        IEnumerable<Permission> GetPermissionsByUserId(string userId);
        Permission Add(Permission permission);
        void Update(Permission permission);
        Permission Delete(int id);
        void DeleteAll(string functionId);
    }
}