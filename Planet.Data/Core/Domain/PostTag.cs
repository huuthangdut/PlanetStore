using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 0)]
        public int PostId { get; set; }

        [Key]
        [Column(TypeName = "varchar", Order = 1)]
        [StringLength(50)]
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
