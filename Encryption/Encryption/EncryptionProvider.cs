using Encryption.Configuration;

namespace Encryption.Encryption
{
    public class EncryptionProvider : IEncryptionProvider
    {
        private readonly IAppConfigurationUpdater _appConfigurationUpdater;
        private readonly IEncryptionService _encryptionService;

        public EncryptionProvider(IEncryptionService encryptionService,
            IAppConfigurationUpdater appConfigurationUpdater)
        {
            _encryptionService = encryptionService;
            _appConfigurationUpdater = appConfigurationUpdater;
        }

        public string Provide(string sectionName, string text)
        {
            if (_encryptionService.TryDecrypt(text, out var result))
            {
                return result;
            }

            var encryptedText = _encryptionService.Encrypt(text);
            _appConfigurationUpdater.Update(sectionName, encryptedText);

            return text;
        }
    }
}