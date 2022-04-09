using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace BlazorRCM.Shared.Extensions
{
    public class GetAppsettingsExtension
    {

        #region Methods

        public static string GetSettingValue(string MainKey, string SubKey)
        {
            return Configuration.GetSection(MainKey).GetValue<string>(SubKey);
        }

        #endregion

        #region Properties

        public static IConfigurationRoot? _configuration;
        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();
                    _configuration = builder.Build();

                }
                return _configuration;
            }
        }
        public static string GetConnString
        {
            get
            {
                return Configuration.GetSection("ConnectionStrings").GetValue<string>("RCMpostgreConnection");
            }
        }

        #endregion

    }
}
