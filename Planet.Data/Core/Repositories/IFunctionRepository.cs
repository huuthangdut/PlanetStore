using System.Collections.Generic;
using Function = Planet.Data.Core.Domain.Function;

namespace Planet.Data.Core.Repositories
{
    public interface IFunctionRepository : IRepository<Domain.Function>
    {
        List<Function> GetFunctionsByUserId(string userId);
    }
}
