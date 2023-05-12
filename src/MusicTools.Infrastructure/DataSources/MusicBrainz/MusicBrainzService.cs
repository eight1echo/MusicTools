namespace MusicTools.Infrastructure.DataSources.MusicBrainz;
public class MusicBrainzService : IMusicBrainzService
{
    public async Task<List<string>> GetGenres(Query query)
    {
        List<string> genres = new();
        var q = new MetaBrainz.MusicBrainz.Query("Test", "1.0", "mailto:a.ols@outlook.com");

        var response = await q.FindReleaseGroupsAsync($"artist:{query.Artist} AND release:{query.Title}");

        if (response.Results.Any())
        {
            var release = response.Results[0];

            if (release.Item.Tags is not null && release.Item.Tags.Any())
            {
                foreach (var tag in release.Item.Tags)
                {
                    genres.Add(tag.Name);
                }
            }
        }

        return genres;
    }
}