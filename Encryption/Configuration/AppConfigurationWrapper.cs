using Encryption.Encryption;

namespace Encryption.Configuration
{
    public class AppConfigurationWrapper : IAppConfigurationWrapper
    {
        private const string UsernameSectionName = "AppConfiguration:Username";
        private const string PasswordSectionName = "AppConfiguration:Password";

        private readonly IAppConfigurationProvider _appConfigurationProvider;
        private readonly IEncryptionProvider _encryptionProvider;

        public AppConfigurationWrapper(
            IAppConfigurationProvider appConfigurationProvider,
            IEncryptionProvider encryptionProvider)
        {
            _appConfigurationProvider = appConfigurationProvider;
            _encryptionProvider = encryptionProvider;

            Sanitize();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        private void Sanitize()
        {
            var usernameValue = GetValueFromConfiguration(UsernameSectionName);
            var passwordValue = GetValueFromConfiguration(PasswordSectionName);
            Username = ProvideEncryption(UsernameSectionName, usernameValue);
            Password = ProvideEncryption(PasswordSectionName, passwordValue);
        }

        public string ProvideEncryption(string sectionName, string text)
        {
            return _encryptionProvider.Provide(sectionName, text);
        }

        public string GetValueFromConfiguration(string sectionName)
        {
            return _appConfigurationProvider.GetValue(sectionName);
        }
    }
}