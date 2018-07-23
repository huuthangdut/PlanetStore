using System.Collections.Generic;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
        }

        public Permission Add(Permission permission)
        {
            return _permissionRepository.Add(permission);
        }

        public void Update(Permission permission)
        {
            _permissionRepository.Update(permission);
        }

        public Permission Delete(int id)
        {
            return _permissionRepository.Delete(id);
        }

        public void DeleteAll(string functionId)
        {
            _permissionRepository.Delete(x => x.FunctionId == functionId);
        }

        public Permission Get(string roleId, string functionId)
        {
            return _permissionRepository.Find(p => p.FunctionId == functionId && p.RoleId == roleId);
        }

        public IEnumerable<Permission> GetAll()
        {
            return _permissionRepository.GetAll();
        }

        public IEnumerable<Permission> GetPermissionsByFunctionId(string functionId)
        {
            return _permissionRepository.Filter(p => p.FunctionId == functionId);
        }

        public IEnumerable<Permission> GetPermissionsByRoleId(string roleId)
        {
            return _permissionRepository.Filter(p => p.RoleId == roleId, "Function");
        }

        public IEnumerable<Permission> GetPermissionsByUserId(string userId)
        {
            return _permissionRepository.GetByUserId(userId);
        }

    }
}
