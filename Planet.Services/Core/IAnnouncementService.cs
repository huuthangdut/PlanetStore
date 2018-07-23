using Planet.Data.Core.Domain;
using System.Collections.Generic;

namespace Planet.Services.Core
{
    public interface IAnnouncementService
    {
        Announcement Add(Announcement announcement);

        Announcement GetById(int id);

        void Delete(int id);

        void Delete(Announcement announcement);

        void MarkAsRead(string userId, int announcementId);

        IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int pageIndex, int pageSize,
            out int totalItems);

        IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int top);

        IEnumerable<Announcement> GetAll(int pageIndex, int pageSize, out int totalItems);

        IEnumerable<Announcement>
            GetUnreadAnnouncements(string userId, int pageIndex, int pageSize, out int totalItems);
    }
}
