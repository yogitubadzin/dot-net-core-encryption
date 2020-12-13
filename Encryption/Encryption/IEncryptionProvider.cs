namespace Encryption.Encryption
{
    public interface IEncryptionProvider
    {
        string Provide(string sectionName, string text);
    }
}