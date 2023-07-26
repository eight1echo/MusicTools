namespace MusicTools.Features;
public class FindGenres : IFindGenres
{
    private readonly ILastFMService _lastFM;

    public FindGenres(ILastFMService lastFM)
    {
        _lastFM = lastFM;
    }

    public async Task<List<string>> SendGenreQuery(Query query)
    {
        List<string> genres = new();

        var results = await _lastFM.GenreQuery(query);
        if (results.Any())
            genres.AddRange(results);

        return genres;
    }
}
