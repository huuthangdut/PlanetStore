using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Products")]
    public class Product : AuditSeoable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Alias { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public int ManufacturerId { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public string ThumbnailImage { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool IncludedVAT { get; set; }

        public int? Warranty { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
