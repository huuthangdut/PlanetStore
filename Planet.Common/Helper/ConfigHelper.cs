using System.Configuration;

namespace Planet.Common.Helper
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
