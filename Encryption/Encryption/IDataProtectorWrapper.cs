namespace Encryption.Encryption
{
    public interface IDataProtectorWrapper
    {
        string Unprotect(string protectedData);

        string Protect(string unprotectedData);
    }
}