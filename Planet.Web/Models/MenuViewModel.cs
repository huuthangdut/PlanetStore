using System.ComponentModel.DataAnnotations;

namespace Planet.Web.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ParentId { get; set; }

        [StringLength(10)]
        public string Target { get; set; }
    }
}