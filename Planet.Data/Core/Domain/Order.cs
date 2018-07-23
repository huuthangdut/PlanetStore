using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public DateTime OrderDate { get; set; }

        public string PaymentStatus { get; set; }

        public decimal TotalAmount { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser Customer { get; set; }

        [ForeignKey("StatusId")]
        public virtual OrderStatus Status { get; set; }

        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
