namespace MusicTools.Features.FindImages;

public interface IFindImages
{
    Task<List<Image>> SendImageQuery(Query query);
}