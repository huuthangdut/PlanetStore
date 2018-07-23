using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(250)]
        [Required]
        public string Address { get; set; }

        [StringLength(50)]
        [Required]
        public string Ward { get; set; }

        [StringLength(50)]
        [Required]
        public string District { get; set; }

        [StringLength(50)]
        [Required]
        public string Province { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool Status { get; set; }
    }
}
