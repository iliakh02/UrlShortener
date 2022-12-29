using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Models;

namespace UrlShortener.WebAPI.DAL
{
    public class LinkRepository : ILinkRepository, IDisposable
    {
        private readonly UrlShortenerDbContext _context;

        public LinkRepository(UrlShortenerDbContext context)
        {
            _context = context;
        }

        public async Task AddLinkAsync(Link link)
        {
            await _context.Links.AddAsync(link);
        }

        public async Task DeleteLinkByIdAsync(int id)
        {
            Link link = await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
            _context.Links.Remove(link);
        }

        public async Task<IEnumerable<Link>> GetAllLinksAsync()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> GetLinkByShortUrlAsync(string shortUrl)
        {
            return await _context.Links.FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
        }

        public void DeleteAllLinks()
        {
            _context.Links.RemoveRange(_context.Links);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
