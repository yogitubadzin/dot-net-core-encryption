using System.Security.Cryptography;

namespace Encryption.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IDataProtectorWrapper _dataProtectorWrapper;

        public EncryptionService(IDataProtectorWrapper dataProtectorWrapper)
        {
            this._dataProtectorWrapper = dataProtectorWrapper;
        }

        public string Encrypt(string text)
        {
            return _dataProtectorWrapper.Protect(text);
        }

        public string Decrypt(string encryptedText)
        {
            return _dataProtectorWrapper.Unprotect(encryptedText);
        }

        public bool TryDecrypt(string encryptedText, out string decryptedText)
        {
            try
            {
                decryptedText = _dataProtectorWrapper.Unprotect(encryptedText);

                return true;
            }
            catch (CryptographicException)
            {
                decryptedText = null;

                return false;
            }
        }
    }
}