namespace MusicTools.Infrastructure.Azure;

public interface IAzureKeyVaultService
{
    Task<string> GetSecretAsync(string secretName);
}