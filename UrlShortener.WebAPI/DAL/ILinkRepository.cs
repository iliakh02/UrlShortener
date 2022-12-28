using UrlShortener.WebAPI.Models;

namespace UrlShortener.WebAPI.DAL
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> GetAllLinksAsync();
        Task<Link> GetLinkByShortUrlAsync(string shortLink);
        Task AddLinkAsync(Link link);
        Task DeleteLinkByIdAsync(int id);
        void DeleteAllLinks();
        Task SaveAsync();

    }
}
