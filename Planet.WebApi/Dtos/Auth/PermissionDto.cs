namespace Planet.WebApi.Dtos.Auth
{
    public class PermissionDto
    {
        public string RoleId { get; set; }

        public string FunctionId { get; set; }

        public bool CanCreate { set; get; }

        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public AppRoleDto AppRole { get; set; }

        public FunctionDto Function { get; set; }
    }
}