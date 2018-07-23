using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planet.Services.Persistence
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IAnnouncementUserRepository _announcementUserRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IAnnouncementUserRepository announcementUserRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementUserRepository = announcementUserRepository;
        }

        public Announcement Add(Announcement announcement)
        {
            return _announcementRepository.Add(announcement);
        }

        public Announcement GetById(int id)
        {
            return _announcementRepository.Find(id);
        }

        public void Delete(int id)
        {
            _announcementRepository.Delete(id);
        }

        public void Delete(Announcement announcement)
        {
            _announcementRepository.Delete(announcement);
        }

        public void MarkAsRead(string userId, int announcementId)
        {
            var announcement =
                _announcementUserRepository.Find(au => au.UserId == userId && au.AnnouncementId == announcementId,
                    "AppUser");

            if (announcement == null)
            {
                _announcementUserRepository.Add(new AnnouncementUser
                {
                    AnnouncementId = announcementId,
                    UserId = userId,
                    HasRead = true
                });
            }
            else
            {
                announcement.HasRead = true;
            }
        }

        public IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int pageIndex, int pageSize, out int totalItems)
        {
            return _announcementRepository.GetAnnouncementsByUserId(userId, pageIndex, pageSize, out totalItems);
        }

        public IEnumerable<Announcement> GetAnnouncementsByUserId(string userId, int top)
        {
            return _announcementRepository.GetAnnouncementsByUserId(userId, top);
        }

        public IEnumerable<Announcement> GetAll(int pageIndex, int pageSize, out int totalItems)
        {
            return _announcementRepository.Filter(null, a => a.DateCreated, ListSortDirection.Descending, out totalItems, pageIndex, pageSize);
        }

        public IEnumerable<Announcement> GetUnreadAnnouncements(string userId, int pageIndex, int pageSize, out int totalItems)
        {
            return _announcementRepository.GetUnreadAnnouncementsByUserId(userId, pageIndex, pageSize, out totalItems);
        }
    }
}
