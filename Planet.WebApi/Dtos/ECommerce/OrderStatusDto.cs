using System.ComponentModel.DataAnnotations;

namespace Planet.WebApi.Dtos.ECommerce
{
    public class OrderStatusDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}