using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System.Collections.Generic;

namespace Planet.Services.Persistence
{
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _slideRepository;

        public SlideService(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetAll();
        }
    }
}
