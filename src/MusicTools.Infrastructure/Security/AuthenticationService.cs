namespace MusicTools.Infrastructure.Security;
public class AuthenticationService : IAuthenticationService
{
    private readonly IAzureKeyVaultService _keyVault;

    public AuthenticationService(IAzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
    }

    public async Task<DiscogsCredentials> AuthenticateDiscogs()
    {
        var token = await _keyVault.GetSecretAsync("DiscogsToken");

        return new DiscogsCredentials(token);
    }

    public async Task<LastFMCredentials> AuthenticateLastFM()
    {
        var apiKey = await _keyVault.GetSecretAsync("LastFMApiKey");
        var apiSecret = await _keyVault.GetSecretAsync("LastFMApiSecret");

        return new LastFMCredentials(apiKey, apiSecret);
    }
}
