using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.WebAPI.Models
{
    public class UrlShortenerDbContext : IdentityDbContext
    {
        public DbSet<Link> Links { get; set; }
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        { }
    }
}
