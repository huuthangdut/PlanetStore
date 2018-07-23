using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Taxs")]
    public class Tax
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public decimal Percentage { get; set; }
    }
}
