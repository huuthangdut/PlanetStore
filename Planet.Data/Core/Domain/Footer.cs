using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
