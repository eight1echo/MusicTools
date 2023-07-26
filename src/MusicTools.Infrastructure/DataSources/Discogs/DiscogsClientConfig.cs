namespace MusicTools.Infrastructure.DataSources.Discogs;
public class DiscogsClientConfig : IClientConfig
{
    public string? AuthToken { get; set; }

    public string? BaseUrl => "https://api.discogs.com";
}