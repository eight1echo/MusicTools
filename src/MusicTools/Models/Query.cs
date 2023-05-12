namespace MusicTools.Models;

public class Query
{
    public string Artist { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string UPC { get; set; } = string.Empty;
    public DataSource Source { get; set; } = DataSource.All;
}
