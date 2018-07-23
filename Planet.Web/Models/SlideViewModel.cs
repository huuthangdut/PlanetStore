namespace Planet.Web.Models
{
    public class SlideViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public int Status { get; set; }
    }
}