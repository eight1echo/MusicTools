namespace MusicTools.Interfaces;

public interface IFindGenres
{
    Task<List<string>> SendGenreQuery(Query query);
}