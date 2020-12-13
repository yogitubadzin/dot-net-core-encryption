using System;
using System.IO;
using Encryption.Configuration;
using Encryption.Encryption;
using Encryption.Serialization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Encryption.Ioc
{
    public static class Bootstrapper
    {
        public static IServiceProvider GetServiceProvider(Action<ServiceCollection> action = null)
        {
            var services = new ServiceCollection();

            RegisterConfiguration(services);
            RegisterEncryption(services);
            RegisterUtils(services);

            return services.BuildServiceProvider();
        }

        private static void RegisterConfiguration(ServiceCollection services)
        {
            services.AddSingleton<IAppConfigurationUpdater, AppConfigurationUpdater>();
            services.AddSingleton<IAppConfigurationProvider, AppConfigurationProvider>();
            services.AddSingleton<IAppConfigurationWrapper, AppConfigurationWrapper>();
        }

        private static void RegisterEncryption(ServiceCollection services)
        {
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"c:\data-protector"))
                .ProtectKeysWithDpapi();

            services.AddSingleton<IDataProtectorWrapper, DataProtectorWrapper>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IEncryptionProvider, EncryptionProvider>();
        }

        private static void RegisterUtils(ServiceCollection services)
        {
            services.AddSingleton<ISerializer, Serializer>();
        }
    }
}