namespace Encryption.Configuration
{
    public interface IAppConfigurationUpdater
    {
        void Update(string key, string value);
    }
}