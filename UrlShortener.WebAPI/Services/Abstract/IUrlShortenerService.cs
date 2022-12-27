namespace UrlShortener.WebAPI.Services.Abstract
{
    public interface IUrlShortenerService
    {
        string GenerateShortURL(string url);
    }
}
