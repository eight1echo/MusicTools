namespace MusicTools.Interfaces;

public interface IWebScrapingClient
{
    Task<Image?> VintageVinylImage(Query query);
}