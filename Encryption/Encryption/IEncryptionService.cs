namespace Encryption.Encryption
{
    public interface IEncryptionService
    {
        string Encrypt(string text);

        string Decrypt(string encryptedText);

        bool TryDecrypt(string encryptedText, out string decryptedText);
    }
}