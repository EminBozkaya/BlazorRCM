using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
//using Microsoft.Extensions.Configuration.EnvironmentalVariables;
//using Microsoft.Extensions.Configuration.FileExtensions;

namespace RCMServerData.EFContext
{
    public class AppSettings
    {
        private static AppSettings? _appSettings;

        public string AppConnection { get; set; }

        public AppSettings(IConfiguration config)
        {
            this.AppConnection = config.GetValue<string>("RCMpostgreConnection");

            // Now set Current
            _appSettings = this;
        }

        public static AppSettings Current
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = GetCurrentSettings();
                }

                return _appSettings;
            }
        }

        public static AppSettings GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettings(configuration.GetSection("ConnectionStrings"));
            //var settings = new AppSettings(configuration.GetSection("AppSettings"));

            return settings;
        }
    }
}
