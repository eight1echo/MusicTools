namespace MusicTools.Infrastructure.Azure;
public class AzureKeyVaultService : IAzureKeyVaultService
{
    public async Task<string> GetSecretAsync(string secretName, string vaultName)
    {
        var client = new SecretClient(new Uri($"https://{vaultName}.vault.azure.net"), new DefaultAzureCredential());

        KeyVaultSecret secret = await client.GetSecretAsync(secretName);

        return secret.Value;
    }
}
