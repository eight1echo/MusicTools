namespace MusicTools.Interfaces;

public interface ILastFMService
{
    Task<Image?> ImageQuery(Query query);
    Task<List<string>> GenreQuery(Query query);
}