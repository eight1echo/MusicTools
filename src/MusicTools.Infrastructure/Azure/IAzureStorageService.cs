namespace MusicTools.Infrastructure.Azure;

public interface IAzureStorageService
{
    Task<Stream> ReadFromStorage(string containerName, string fileName);
    Task UploadToStorage(string containerName, string fileName, IBrowserFile file);
}