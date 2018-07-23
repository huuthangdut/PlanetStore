using Microsoft.AspNet.Identity.EntityFramework;
using Planet.Data.Core.Domain;
using Planet.Data.Persistence;

namespace Planet.Infrastructure.Identity
{
    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(PlanetContext context) : base(context)
        {
        }
    }
}