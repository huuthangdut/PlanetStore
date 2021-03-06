﻿using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Services.Core
{
    public interface ISlideService
    {
        IEnumerable<Slide> GetSlides();
    }
}
