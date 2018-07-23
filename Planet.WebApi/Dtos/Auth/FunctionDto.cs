namespace Planet.WebApi.Dtos.Auth
{
    public class FunctionDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int DisplayOrder { get; set; }

        public string ParentId { get; set; }

        public string IconCss { get; set; }
    }
}