namespace Encryption.Configuration
{
    public interface IAppConfigurationProvider
    {
        string GetValue(string sectionName);
    }
}