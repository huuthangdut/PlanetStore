using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("SupplierTags")]
    public class SupplierTag
    {
        [Key]
        [Column(Order = 0)]
        public int SupplierId { get; set; }

        [Key]
        [Column(TypeName = "varchar", Order = 1)]
        [StringLength(50)]
        public string TagId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
