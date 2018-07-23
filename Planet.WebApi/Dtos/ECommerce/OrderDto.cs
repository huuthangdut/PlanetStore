using Planet.WebApi.Dtos.Auth;
using System.Collections.Generic;

namespace Planet.WebApi.Dtos.ECommerce
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Ward { get; set; }

        public string District { get; set; }

        public string Province { get; set; }

        public string PhoneNumber { get; set; }

        public string Comments { get; set; }

        public int PaymentMethodId { get; set; }

        public string OrderDate { get; set; }

        public string PaymentStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public int StatusId { get; set; }

        public virtual AppUserDto Customer { get; set; }

        public virtual OrderStatusDto Status { get; set; }

        public virtual PaymentMethodDto PaymentMethod { get; set; }

        public virtual IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}