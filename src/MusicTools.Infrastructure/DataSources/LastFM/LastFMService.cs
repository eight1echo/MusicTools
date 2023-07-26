namespace MusicTools.Infrastructure.DataSources.LastFM;
public class LastFMService : ILastFMService
{
    private readonly IAuthenticationService _authentication;

    public LastFMService(IAuthenticationService authentication)
    {
        _authentication = authentication;
    }

    public async Task<List<string>> GenreQuery(Query query)
    {
        var credentials = await _authentication.AuthenticateLastFM();
        var client = new LastfmClient(credentials.ApiKey, credentials.ApiSecret);

        var response = await client.Artist.GetTopTagsAsync(query.Artist, autocorrect: true);

        if (response.Content.Any())
        {
            List<string> tags = response.Content.Take(10).Select(tag => tag.Name).ToList();
            return tags;
        }

        return new List<string>();
    }

    public async Task<Image?> ImageQuery(Query query)
    {
        if (query.Artist is not null && query.Title is not null)
        {
            var credentials = await _authentication.AuthenticateLastFM();

            var client = new LastfmClient(credentials.ApiKey, credentials.ApiSecret);

            var response = await client.Album.GetInfoAsync(query.Artist, query.Title, autocorrect: true);

            var album = response.Content;

            if (album is null || album.Images.Largest is null)
            {
                return null;
            }

            return new Image(album.Images.Largest.AbsoluteUri);
        }

        return null;
    }
}
