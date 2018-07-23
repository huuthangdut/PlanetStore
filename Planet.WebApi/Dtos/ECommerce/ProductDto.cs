using System;
using System.Collections.Generic;

namespace Planet.WebApi.Dtos.ECommerce
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public string SKU { get; set; }

        public string ThumbnailImage { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool IncludedVAT { get; set; }

        public int? Warranty { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public DateTime? DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public int Status { get; set; }

        public virtual ProductCategoryDto ProductCategory { get; set; }

        public virtual IEnumerable<ProductImageDto> Images { get; set; }
    }
}