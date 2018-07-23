namespace Planet.Common
{
    public static class UploadPath
    {
        public const string PrefixWebApi = "http://localhost:5200";
        public const string Root = "/UploadedFiles/";
        public const string Avatar = "/UploadedFiles/Avatars/";
        public const string Product = "/UploadedFiles/Products/";
        public const string News = "/UploadedFiles/News/";
        public const string Banner = "/UploadedFiles/Banners/";
    }

    public static class UploadType
    {
        public const string Avatar = "avatar";
        public const string Product = "product";
        public const string News = "news";
        public const string Banner = "banner";
    }

    public static class UploadValidation
    {
        public static string[] AllowFileExtensions = { ".jpg", ".gif", ".png" };
        public const int MaxContentLength = 1024 * 1024 * 1; // Size = 1 MB
    }
}
