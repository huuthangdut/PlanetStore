using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ParentId { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public bool Status { get; set; }

        [ForeignKey("ParentId")]
        public virtual Menu ParentMenu { get; set; }
    }
}
