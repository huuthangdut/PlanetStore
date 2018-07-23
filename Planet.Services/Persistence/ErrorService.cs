using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;

        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public Error Add(Error error)
        {
            return this._errorRepository.Add(error);
        }
    }
}
