using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Planet.Data.Persistence.Repositories
{
    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int top)
        {
            var query = (from a in DbContext.Announcements
                         join au in DbContext.AnnouncementUsers on a.Id equals au.AnnouncementId
                         where au.UserId == userId
                         select a).Take(top);

            return query;
        }

        public IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int pageIndex, int pageSize, out int totalItems)
        {
            var query = (from a in DbContext.Announcements
                         join au in DbContext.AnnouncementUsers on a.Id equals au.AnnouncementId
                         where au.UserId == userId
                         orderby a.DateCreated descending
                         select a);

            totalItems = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }

        public IEnumerable<Announcement> GetUnreadAnnouncementsByUserId(string userId, int pageIndex, int pageSize, out int totalItems)
        {
            var query = (from a in DbContext.Announcements
                         join au in DbContext.AnnouncementUsers on a.Id equals au.AnnouncementId
                         where au.UserId == userId && au.HasRead == false
                         orderby a.DateCreated descending
                         select a);

            totalItems = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}
