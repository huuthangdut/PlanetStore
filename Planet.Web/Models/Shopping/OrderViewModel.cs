using Planet.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planet.Web.Models.Shopping
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng nhập họ.")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Quốc gia")]
        [Required(ErrorMessage = "Vui lòng nhập quốc gia.")]
        public string Country { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        [Required(ErrorMessage = "Vui lòng nhập tỉnh/thành phố.")]
        public string Province { get; set; }

        [Display(Name = "Quận/Huyện")]
        [Required(ErrorMessage = "Vui lòng nhập quận/huyện.")]
        public string District { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ghi chú đơn hàng")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán.")]
        public int PaymentMethodId { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Trạng thái giao hàng")]
        public string OrderStatus { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal TotalAmount { get; set; }

        public AppUser Customer { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}