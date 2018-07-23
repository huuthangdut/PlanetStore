using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Type { get; set; }
    }
}
