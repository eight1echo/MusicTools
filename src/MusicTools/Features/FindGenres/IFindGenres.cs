namespace MusicTools.Features.FindGenres;

public interface IFindGenres
{
    Task<List<string>> SendGenreQuery(Query query);
}