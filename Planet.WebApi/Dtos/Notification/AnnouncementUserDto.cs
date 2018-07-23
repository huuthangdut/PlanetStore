using Planet.WebApi.Dtos.Auth;

namespace Planet.WebApi.Dtos.Notification
{
    public class AnnouncementUserDto
    {
        public int AnnouncementId { get; set; }

        public string UserId { get; set; }

        public bool HasRead { get; set; }

        public virtual AppUserDto AppUser { get; set; }

        public virtual AnnouncementDto Announcement { get; set; }
    }
}