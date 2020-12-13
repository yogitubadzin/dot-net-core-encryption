using System.Diagnostics;
using System.IO;
using Encryption.Serialization;
using Newtonsoft.Json;

namespace Encryption.Configuration
{
    public class AppConfigurationUpdater : IAppConfigurationUpdater
    {
        private readonly string _appSettingFileName = "appSettings.json";
        private readonly ISerializer _serializer;

        public AppConfigurationUpdater(ISerializer serializer)
        {
            this._serializer = serializer;
        }

        public void Update(string key, string value)
        {
            var basePath = GetBasePath();
            var filePath = Path.Combine(basePath, _appSettingFileName);
            var json = File.ReadAllText(filePath);
            dynamic jsonObj = _serializer.Deserialize<object>(json);

            var sectionPath = key.Split(":")[0];
            if (!string.IsNullOrEmpty(sectionPath))
            {
                var keyPath = key.Split(":")[1];
                jsonObj[sectionPath][keyPath] = value;
            }
            else
            {
                jsonObj[sectionPath] = value;
            }

            string output = _serializer.Serialize(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }

        private string GetBasePath()
        {
            using var processModule = Process.GetCurrentProcess().MainModule;
            return Path.GetDirectoryName(processModule?.FileName);
        }
    }
}