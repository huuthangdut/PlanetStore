using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Planet.Web.Models.Products
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        public string ImageUrl { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? DateUpdated { get; set; }

        public IEnumerable<ProductCategoryViewModel> Chidlren { get; set; }
    }
}