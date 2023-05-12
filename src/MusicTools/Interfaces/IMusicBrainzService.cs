namespace MusicTools.Interfaces;

public interface IMusicBrainzService
{
    Task<List<string>> GetGenres(Query query);
}