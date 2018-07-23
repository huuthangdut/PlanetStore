using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("AttributeValues")]
    public class AttributeValue
    {
        [Key]
        public int Id { get; set; }

        public int AttributeId { get; set; }

        public string Value { get; set; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }
    }
}
