using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IPageService
    {
        Page GetByAlias(string alias);
    }
}