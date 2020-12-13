using System.IO;
using Microsoft.Extensions.Configuration;

namespace Encryption.Configuration
{
    public class AppConfigurationProvider : IAppConfigurationProvider
    {
        private readonly string _appSettingFileName = "appSettings.json";
        private readonly IConfiguration _config;

        public AppConfigurationProvider()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile(_appSettingFileName, false, true)
                .AddEnvironmentVariables()
                .SetBasePath(GetBasePath())
                .Build();
        }

        public string GetValue(string sectionName)
        {
            return _config.GetSection(sectionName).Value;
        }

        private string GetBasePath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}