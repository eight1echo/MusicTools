using Azure.Security.KeyVault.Secrets;

namespace MusicTools.Infrastructure.Azure;
public class AzureKeyVaultService : IAzureKeyVaultService
{
    private readonly SecretClient _secretClient;

    public AzureKeyVaultService(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }
    public async Task<string> GetSecretAsync(string secretName)
    {
        KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);

        return secret.Value;
    }
}
