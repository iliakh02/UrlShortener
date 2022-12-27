using System.Xml;
using UrlShortener.WebAPI.Models;

namespace UrlShortener.WebAPI.DAL
{
    public class LinkRepository : ILinkRepository, IDisposable
    {
        private UrlShortenerDbContext _context;

        public LinkRepository(UrlShortenerDbContext context)
        {
            _context = context;
        }

        public void AddLink(Link link)
        {
            _context.Links.Add(link);
        }

        public void DeleteLinkById(int id)
        {
            Link link = _context.Links.Find(id);
            _context.Links.Remove(link);
        }

        public IEnumerable<Link> GetAllLinks()
        {
            return _context.Links.ToList();
        }

        public Link GetLinkByShortUrl(string shortLink)
        {
            return _context.Links.FirstOrDefault();
        }

        void ILinkRepository.DeleteAllLinks()
        {
            _context.Links.RemoveRange(context.Links);
        }

        public void Save()
        {
            _context.SaveChanges();
        }



        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed= true;
        }
    }
}
