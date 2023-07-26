namespace MusicTools.Infrastructure.DataSources.WebScraping;
public class WebScrapingClient : IWebScrapingClient
{
    private readonly HttpClient _httpClient;

    public WebScrapingClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://vintagevinyl.com/UPC/");

    }

    public async Task<Image?> VintageVinylImage(Models.Query query)
    {
        if (query == null) return null;

        var html = await _httpClient.GetStringAsync(query.UPC);

        HtmlDocument htmlDoc = new();

        htmlDoc.LoadHtml(html);
        var img = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/main/div/div[2]/div/div[3]/article[1]/div[1]/a/img");

        if (img is not null)
        {
            return new Image(img.Attributes["src"].Value);
        }

        return null;
    }
}
