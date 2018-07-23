using System;
using System.ComponentModel.DataAnnotations;

namespace Planet.Data.Core
{
    public abstract class AuditSeoable
    {
        public DateTime? DateCreated { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }

        [StringLength(255)]
        public string UpdatedBy { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(1000)]
        public string MetaKeyword { get; set; }

        [StringLength(255)]
        public string MetaDescription { get; set; }

        public int Status { get; set; }
    }
}
