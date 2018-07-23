using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Carts")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }

        public string Attributes { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public Product Product { get; set; }
    }
}
