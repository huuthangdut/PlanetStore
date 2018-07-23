using Planet.Data.Core;

namespace Planet.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private PlanetContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public PlanetContext DbContext
        {
            get
            {
                return _context ?? (_context = _dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
