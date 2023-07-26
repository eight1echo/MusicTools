namespace MusicTools.Features;
public class FindImages : IFindImages
{
    private readonly IDiscogsService _discogs;
    private readonly ILastFMService _lastfm;
    private readonly IWebScrapingClient _webScraping;

    public FindImages(IDiscogsService discogs, ILastFMService lastfm, IWebScrapingClient webScraping)
    {
        _discogs = discogs;
        _lastfm = lastfm;
        _webScraping = webScraping;
    }

    public async Task<List<Image>> SendImageQuery(Query query)
    {
        List<Image> images = new();

        switch (query.Source)
        {
            case DataSource.All:

                var lastfmResult = await _lastfm.ImageQuery(query);
                if (lastfmResult is not null)
                    images.Add(lastfmResult);

                var vvResult = await _webScraping.VintageVinylImage(query);
                if (vvResult is not null)
                    images.Add(vvResult);

                var discogsResult = await _discogs.ImageQuery(query);
                if (discogsResult.Any())
                    images.AddRange(discogsResult);

                break;

            case DataSource.LastFM:

                lastfmResult = await _lastfm.ImageQuery(query);
                if (lastfmResult is not null)
                    images.Add(lastfmResult);

                break;

            case DataSource.Discogs:

                discogsResult = await _discogs.ImageQuery(query);
                if (discogsResult.Any())
                    images.AddRange(discogsResult);

                break;

            case DataSource.WebScrape:

                vvResult = await _webScraping.VintageVinylImage(query);
                if (vvResult is not null)
                    images.Add(vvResult);

                break;
        }

        return images;
    }
}
