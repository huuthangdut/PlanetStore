using System;

namespace Planet.WebApi.Dtos.ECommerce
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int Status { get; set; }
    }
}