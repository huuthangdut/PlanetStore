using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Planet.Data.Core.Domain
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name, string description) : base(name)
        {
            Description = description;
        }

        [StringLength(256)]
        public virtual string Description { get; set; }
    }
}
