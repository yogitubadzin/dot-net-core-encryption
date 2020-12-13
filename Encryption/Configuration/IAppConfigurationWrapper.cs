namespace Encryption.Configuration
{
    public interface IAppConfigurationWrapper
    {
        string Username { get; set; }

        string Password { get; set; }
    }
}