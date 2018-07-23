using System;
using System.ComponentModel.DataAnnotations;

namespace Planet.Web.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        [Display(Name = "Tên *")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề *")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
        public string Subject { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Vui lòng nhập nội dung.")]
        [Display(Name = "Nội dung *")]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public bool? Status { get; set; }

        public ContactViewModel ContactInfo { get; set; }
    }
}