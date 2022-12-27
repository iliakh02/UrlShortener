using Microsoft.EntityFrameworkCore;

namespace UrlShortener.WebAPI.Models
{
    public class UrlShortenerDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        { }
    }
}
