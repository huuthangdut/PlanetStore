using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IFunctionService
    {
        IEnumerable<Function> GetAll();

        IEnumerable<Function> GetSpecifiedByUser(string userId);

        IEnumerable<Function> GetAllWithParentId(string parentId);

        Function GetById(string id);

        Function Add(Function function);

        void Update(Function function);

        void Delete(string id);

        bool Contains(string id);
    }
}