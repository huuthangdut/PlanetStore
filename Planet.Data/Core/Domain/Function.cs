using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Functions")]
    public class Function
    {
        [Key]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public int DisplayOrder { get; set; }

        public bool Status { get; set; }

        public string IconCss { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Function ParentFunction { get; set; }


    }
}
