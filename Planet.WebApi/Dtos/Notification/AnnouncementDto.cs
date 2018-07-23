using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planet.WebApi.Dtos.Notification
{
    public class AnnouncementDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<AnnouncementUserDto> AnnouncementUsers { get; set; }
    }
}