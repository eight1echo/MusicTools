namespace MusicTools.Features.FindGenres;
public class FindGenres : IFindGenres
{
    private readonly ILastFMService _lastFM;
    private readonly IMusicBrainzService _musicBrainz;

    public FindGenres(ILastFMService lastFM, IMusicBrainzService musicBrainz)
    {
        _lastFM = lastFM;
        _musicBrainz = musicBrainz;
    }

    public async Task<List<string>> SendGenreQuery(Query query)
    {
        List<string> genres = new();

        switch (query.Source)
        {
            case DataSource.All:

                var lastfmResult = await _lastFM.GenreQuery(query);
                if (lastfmResult.Any())
                    genres.AddRange(lastfmResult);

                var musicBrainzResult = await _musicBrainz.GetGenres(query);
                if (musicBrainzResult.Any())
                    genres.AddRange(musicBrainzResult);

                break;

            case DataSource.LastFM:

                lastfmResult = await _lastFM.GenreQuery(query);
                if (lastfmResult.Any())
                    genres.AddRange(lastfmResult);

                break;

            case DataSource.MusicBrainz:

                musicBrainzResult = await _musicBrainz.GetGenres(query);
                if (musicBrainzResult.Any())
                    genres.AddRange(musicBrainzResult);

                break;
        }

        return genres;
    }
}
