using System.Configuration;

namespace Restful_Booker_API.Utils
{
    public static class AppConfigReader
    {
        public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
    }
}
