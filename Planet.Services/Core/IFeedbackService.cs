using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IFeedbackService
    {
        Feedback Add(Feedback feedback);
    }
}
