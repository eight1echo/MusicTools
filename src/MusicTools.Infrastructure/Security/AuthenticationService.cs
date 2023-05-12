namespace MusicTools.Infrastructure.Security;
public class AuthenticationService : IAuthenticationService
{
    private readonly IAzureKeyVaultService _keyVault;
    private readonly string _vaultName;

    public AuthenticationService(IAzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
        _vaultName = "mykeyvault";
    }

    public async Task<DiscogsCredentials> AuthenticateDiscogs()
    {
        var token = await _keyVault.GetSecretAsync("DiscogsToken", _vaultName);

        return new DiscogsCredentials(token);
    }

    public async Task<LastFMCredentials> AuthenticateLastFM()
    {
        var apiKey = await _keyVault.GetSecretAsync("LastFMApiKey", _vaultName);
        var apiSecret = await _keyVault.GetSecretAsync("LastFMApiSecret", _vaultName);

        return new LastFMCredentials(apiKey, apiSecret);
    }
}
