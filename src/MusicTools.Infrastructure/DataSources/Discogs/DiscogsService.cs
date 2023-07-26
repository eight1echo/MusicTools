namespace MusicTools.Infrastructure.DataSources.Discogs;
public class DiscogsService : IDiscogsService
{
    private readonly IAuthenticationService _authentication;

    public DiscogsService(IAuthenticationService authentication)
    {
        _authentication = authentication;
    }

    public async Task<List<Image>> ImageQuery(Query query)
    {
        List<Image> images = new();

        // Attempt query using product UPC for most accurate results
        if (!string.IsNullOrEmpty(query.UPC))
        {
            var barcodeSearch = new SearchCriteria { Barcode = query.UPC };
            images.AddRange(await ImageSearch(barcodeSearch));
        }

        // If no images found, attempt using artist name and product title
        if (images.Count == 0)
        {
            var titleSearch = new SearchCriteria { Artist = query.Artist, Title = query.Title };
            images.AddRange(await ImageSearch(titleSearch));
        }

        return images;
    }

    private async Task<List<Image>> ImageSearch(SearchCriteria searchCriteria)
    {
        var credentials = await _authentication.AuthenticateDiscogs();

        var client = new DiscogsClient(
            new HttpClient(new HttpClientHandler()),
            new ApiQueryBuilder(new DiscogsClientConfig() { AuthToken = credentials.Token }));

        var result = await client.SearchAllAsync(searchCriteria);

        List<Image> images = new();
        foreach (var i in result.Results)
        {
            if (!i.CoverImage.Contains("spacer.gif"))
            {
                images.Add(new Image(i.CoverImage));
            }
        }

        return images;
    }
}