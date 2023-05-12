using Microsoft.Extensions.DependencyInjection;

namespace MusicTools.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddAzureServices(this IServiceCollection services)
    {
        services.AddTransient<IAzureKeyVaultService, AzureKeyVaultService>();
        services.AddTransient<IAzureStorageService, AzureStorageService>();

        return services;
    }

    public static IServiceCollection AddDataSources(this IServiceCollection services)
    {
        services.AddSingleton<IApiQueryBuilder, ApiQueryBuilder>();
        services.AddSingleton<IClientConfig, DiscogsClientConfig>();
        services.AddHttpClient<IDiscogsClient, DiscogsClient>()
            .ConfigurePrimaryHttpMessageHandler(_ =>
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
        services.AddTransient<IDiscogsService, DiscogsService>();

        services.AddTransient<ILastFMService, LastFMService>();

        services.AddTransient<IMusicBrainzService, MusicBrainzService>();

        services.AddHttpClient<IWebScrapingClient, WebScrapingClient>();

        return services;
    }

    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddTransient<IFindGenres,FindGenres>();
        services.AddTransient<IFindImages, FindImages>();

        return services;
    }
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        return services;
    }
}