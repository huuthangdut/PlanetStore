using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("ProductCategories")]
    public class ProductCategory : AuditSeoable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(256)]
        public string Alias { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(256)]
        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ParentId")]
        public virtual ProductCategory ParentCategory { get; set; }
    }
}
