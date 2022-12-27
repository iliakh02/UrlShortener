using UrlShortener.WebAPI.Models;

namespace UrlShortener.WebAPI.DAL
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetAllLinks();
        Link GetLinkByShortUrl(string shortLink);
        void AddLink(Link link);
        void DeleteLinkById(int id);
        void DeleteAllLinks();
        void Save();

    }
}
