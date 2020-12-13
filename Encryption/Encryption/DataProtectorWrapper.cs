using Microsoft.AspNetCore.DataProtection;

namespace Encryption.Encryption
{
    public class DataProtectorWrapper : IDataProtectorWrapper
    {
        private const string _purpose = "ProtectConfigData";
        private readonly IDataProtector _dataProtector;

        public DataProtectorWrapper(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(_purpose);
        }

        public string Unprotect(string protectedData)
        {
            return _dataProtector.Unprotect(protectedData);
        }

        public string Protect(string unprotectedData)
        {
            return _dataProtector.Protect(unprotectedData);
        }
    }
}