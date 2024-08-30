using Microsoft.Extensions.Configuration;

namespace HelperClasses
{
    public class AppSettings
    {
        private static IConfiguration _config { get; set; } = null;
        public AppSettings(IConfiguration config) => _config = config;

        //public static IConfiguration GetConfiguration()
        //{
        //    return _config;
        //}

        public static string GetConnectionString()
        {
           return _config.GetSection("AppSettings:ConnectionString").Value??string.Empty;
        }


    }
}
