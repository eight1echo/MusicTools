using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace MusicTools.Infrastructure.Azure;
public class AzureStorageService : IAzureStorageService
{
    private readonly IAzureKeyVaultService _keyVault;

    public AzureStorageService(IAzureKeyVaultService keyVault)
    {
        _keyVault = keyVault;
    }

    public async Task<Stream> ReadFromStorage(string containerName, string fileName)
    {
        string connectionString = await _keyVault.GetSecretAsync("AzureStorageConnectionString");

        var container = new BlobContainerClient(connectionString, containerName);
        var blobClient = container.GetBlockBlobClient(fileName);
        BlobDownloadInfo download = blobClient.Download();

        return download.Content;
    }

    public async Task UploadToStorage(string containerName, string fileName, IBrowserFile file)
    {
        string connectionString = await _keyVault.GetSecretAsync("AzureStorageConnectionString");

        var container = new BlobContainerClient(connectionString, containerName);
        var createResponse = await container.CreateIfNotExistsAsync();

        if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            await container.SetAccessPolicyAsync(PublicAccessType.Blob);

        var blob = container.GetBlobClient(fileName);

        await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

        await blob.UploadAsync(file.OpenReadStream(file.Size));
    }
}