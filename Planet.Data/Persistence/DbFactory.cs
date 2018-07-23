using Planet.Data.Core;

namespace Planet.Data.Persistence
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PlanetContext _context;

        public PlanetContext Init()
        {
            return _context ?? (_context = new PlanetContext());
        }

        protected override void DisposeCore()
        {
            _context?.Dispose();
        }
    }
}
