using Encryption.Configuration;
using Encryption.Ioc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Encryption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //this program sanitizes username and password in appSettings.json during first execution
            var serviceProvider = Bootstrapper.GetServiceProvider();

            var appConfiguration = serviceProvider.GetRequiredService<IAppConfigurationWrapper>();
            Assert.AreEqual(appConfiguration.Username, "postgres");
            Assert.AreEqual(appConfiguration.Password, "postgres-password");

            // result in Encryption\Encryption\bin\Debug\netcoreapp3.1\app.settings.json:
            //
            //{
            //    "AppConfiguration": {
            //        "Username": "CfDJ8HNpY3voduNJlho8S3Y6AJ3-9JJDzIYZrSg94FOlpSrTHVdVZusl9wji1ZdNNi-9KlCx8T5XI_zMpXXWcBeJugB35bxptNOssSKtHsF9bJnXNcEoz528zn_ESxVpV2B6_g",
            //        "Password": "CfDJ8HNpY3voduNJlho8S3Y6AJ2EysGSaRNavarTJiuX-6FVLqhtTrMZvjay9-osalNkJsgvAcsyW3e2LCoC5xyk7EyLpBxG-kazmRPcCOHx5O-VIUmhdWuCppboRUADi0lhchRn4RvJSPHg_rpPBGpxcd4"
            //    }
            //}

            // result in C:\data-protector\key-7b636973-76e8-49e3-961a-3c4b763a009d.xml:
            //
            //<?xml version="1.0" encoding="utf-8"?>
            //<key id="7b636973-76e8-49e3-961a-3c4b763a009d" version="1">
            //  <creationDate>2020-12-12T19:09:05.1657085Z</creationDate>
            //  <activationDate>2020-12-12T19:09:05.1026748Z</activationDate>
            //  <expirationDate>2021-03-12T19:09:05.1026748Z</expirationDate>
            //  <descriptor deserializerType="Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer, Microsoft.AspNetCore.DataProtection, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60">
            //    <descriptor>
            //      <encryption algorithm="AES_256_CBC" />
            //      <validation algorithm="HMACSHA256" />
            //      <encryptedSecret decryptorType="Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor, Microsoft.AspNetCore.DataProtection, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60" xmlns="http://schemas.asp.net/2015/03/dataProtection">
            //        <encryptedKey xmlns="">
            //          <!-- This key is encrypted with Windows DPAPI. -->
            //          <value>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAVtSaBSAPg0qBnoY1sGA0AgAAAAACAAAAAAADZgAAwAAAABAAAABvjvsUeQvZorNtxDTyG5kRAAAAAASAAACgAAAAEAAAAPt5yeoz4gK94AtAX6izwQJIAQAAWf1WuS+lq8zNgMYfVvxnz0ynLqQFFHFN7PsCJbx2onuAxyvwTdFoEFujAOoF2tCAzK8Tq4L2zt68FtcSLT+B8R8nIl1vd/l2apTe76OG0NtU4l3PHNdfb1QrxKfqAonndAechqp8e9nUwe6ia5UuWjeIrLBgk3BYLqGx5wSXTbOdmNmcagPEOAJcmgo1Um47Ni9aJ1ygLxQzL1baowEZeihBERVYjmDn+He2h0Uv7YM6nW2/04RQQz74dUSJS1WNzsKIpHfGOfgXphDSKHrkc99JH4U/ll3ltQkGDnwFvasbQSGKR1RifSPmEXJlGDDPinMbQWBSh/pLXEGIMtU351+0RMLtSlNChrDQTllcNcjdODdFOFlCHJmcAbN/d/Qzf4TZCr2GszDwpwRoAiaiYcPrXVcnTetDobh6uueJjPebTFf26de2SRQAAABGg+edvZloEnl5zs3kaQ1fnrn6kA==</value>
            //        </encryptedKey>
            //      </encryptedSecret>
            //    </descriptor>
            //  </descriptor>
            //</key>
        }
    }
}