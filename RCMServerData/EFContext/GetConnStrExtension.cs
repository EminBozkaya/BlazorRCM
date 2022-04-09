using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMServerData.EFContext
{
    public class GetConnStrExtension
    {
        private static GetConnStrExtension? _GetConnStrExtension;

        public string AppConnection { get; set; }

        public GetConnStrExtension(IConfiguration config)
        {
            this.AppConnection = config.GetValue<string>("RCMpostgreConnection");

            // Now set Current
            _GetConnStrExtension = this;
        }

        public static GetConnStrExtension Current
        {
            get
            {
                if (_GetConnStrExtension == null)
                {
                    _GetConnStrExtension = GetCurrentSettings();
                }

                return _GetConnStrExtension;
            }
        }

        public static GetConnStrExtension GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new GetConnStrExtension(configuration.GetSection("ConnectionStrings"));

            return settings;
        }
    }
}
