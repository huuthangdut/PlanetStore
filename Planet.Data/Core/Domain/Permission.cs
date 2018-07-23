using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planet.Data.Core.Domain
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(128)]
        public string RoleId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "varchar")]
        [StringLength(50)]
        public string FunctionId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        [ForeignKey("RoleId")]
        public AppRole AppRole { get; set; }

        [ForeignKey("FunctionId")]
        public Function Function { get; set; }
    }
}
