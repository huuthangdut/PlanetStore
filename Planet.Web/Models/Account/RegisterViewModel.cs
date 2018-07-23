using System.ComponentModel.DataAnnotations;

namespace Planet.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên.")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên.")]
        public string LastName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu.")]
        public string Password { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu.")]
        public string ConfirmPassword { get; set; }

    }
}