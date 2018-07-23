using System.ComponentModel.DataAnnotations;

namespace Planet.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Tên đăng nhập hoặc email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}