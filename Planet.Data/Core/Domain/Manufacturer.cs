using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Manufacturers")]
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string CompanyName { get; set; }

        public string Website { get; set; }

        public string Logo { get; set; }

        public int? Ranking { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
