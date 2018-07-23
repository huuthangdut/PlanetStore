using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Data.Core.Repositories
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int top);

        IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int pageIndex, int pageSize,
            out int totalItems);

        IEnumerable<Announcement>
            GetUnreadAnnouncementsByUserId(string userId, int pageIndex, int pageSize, out int totalItems);
    }
}
