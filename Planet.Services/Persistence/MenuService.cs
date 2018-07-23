using System.Collections.Generic;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<Menu> GetParentMenu()
        {
            return _menuRepository.Filter(m => m.ParentId == null);
        }

        public IEnumerable<Menu> GetChildrenMenu(int id)
        {
            return _menuRepository.Filter(m => m.ParentId == id);
        }
    }
}
