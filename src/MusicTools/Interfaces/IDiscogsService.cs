namespace MusicTools.Interfaces;

public interface IDiscogsService
{
    Task<List<Image>> ImageQuery(Query query);
}