using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System.Collections.Generic;

namespace Planet.Services.Persistence
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _paymentMethodRepository.GetAll();
        }
    }
}
