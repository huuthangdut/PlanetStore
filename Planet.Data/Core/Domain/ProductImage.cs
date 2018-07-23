using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [StringLength(256)]
        public string Path { get; set; }

        [StringLength(256)]
        public string Caption { get; set; }

        public int Type { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
