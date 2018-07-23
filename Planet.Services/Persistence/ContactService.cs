using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact GetDefaultContact()
        {
            return _contactRepository.Find(c => c.Status);
        }
    }
}
