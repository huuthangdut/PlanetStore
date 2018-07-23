using System.Collections.Generic;
using System.Linq;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public Function GetById(string id)
        {
            return _functionRepository.Find(id);
        }

        public IEnumerable<Function> GetAll()
        {
            return _functionRepository.GetAll();
        }

        public Function Add(Function function)
        {
            return _functionRepository.Add(function);
        }

        public void Update(Function function)
        {
            _functionRepository.Update(function);
        }

        public void Delete(string id)
        {
            _functionRepository.Delete(id);
        }

        public bool Contains(string id)
        {
            return _functionRepository.Contains(x => x.Id == id);
        }

        public IEnumerable<Function> GetAllWithParentId(string parentId)
        {
            return _functionRepository.Filter(x => x.ParentId == parentId);
        }

        public IEnumerable<Function> GetSpecifiedByUser(string userId)
        {
            var query = _functionRepository.GetFunctionsByUserId(userId);
            return query.OrderBy(x => x.ParentId);
        }
    }
}
