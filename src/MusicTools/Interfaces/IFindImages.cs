namespace MusicTools.Interfaces;

public interface IFindImages
{
    Task<List<Image>> SendImageQuery(Query query);
}