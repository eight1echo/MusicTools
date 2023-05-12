namespace MusicTools.Infrastructure.Security;

public interface IAuthenticationService
{
    Task<DiscogsCredentials> AuthenticateDiscogs();
    Task<LastFMCredentials> AuthenticateLastFM();
}