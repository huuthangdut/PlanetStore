using System.ComponentModel.DataAnnotations;

namespace Planet.WebApi.Dtos.ECommerce
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}