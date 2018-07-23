using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Planet.Data.Core.Domain
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        public string Avatar { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager, string authenciationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenciationType);

            return userIdentity;
        }
    }
}
