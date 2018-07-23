using System.Collections.Generic;

namespace Planet.WebApi.Dtos.Auth
{
    public class AppRoleDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}