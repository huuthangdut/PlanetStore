using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetParentMenu();
        IEnumerable<Menu> GetChildrenMenu(int id);
    }
}
