using System;
using Planet.Data.Persistence;

namespace Planet.Data.Core
{
    public interface IDbFactory : IDisposable
    {
        PlanetContext Init();
    }
}
