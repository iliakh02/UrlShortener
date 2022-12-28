using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.DAL;
using UrlShortener.WebAPI.Models;

namespace UrlShortener.UnitTests
{
    public class LinksRepositoryTests
    {
        private readonly DbContextOptions<UrlShortenerDbContext> _dbContextOptions;
        public LinksRepositoryTests()
        {
            var dbName = $"UrlShortenerDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<UrlShortenerDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetAllLinksAsync_ReturnsAllLinksInDatabase()
        {
            // Arrange
            var links = new[]
            {
                new Link
                {
                    ShortUrl = "abc123",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                },
                new Link
                {
                    ShortUrl = "abc124",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                }
            };

            var linksRepository = await GetRepositoryWithMockedData(links);

            // Act
            var result = await linksRepository.GetAllLinksAsync();

            // Assert
            Assert.Equal(links.Length, result.Count());
        }

        [Fact]
        public async Task AddLinkAsync_AddsLinkToDatabase()
        {
            // Arrange
            var linksRepository = new LinkRepository(new UrlShortenerDbContext(_dbContextOptions));

            var link = new Link
            {
                ShortUrl = "abc123",
                FullUrl = "https://example.com",
                CreatedDate = DateTime.Now,
                CreatedBy = "Username"
            };

            // Act
            await linksRepository.AddLinkAsync(link);
            await linksRepository.SaveAsync();


            // Assert
            var allLinks = await linksRepository.GetAllLinksAsync();
            var result = allLinks.FirstOrDefault();
            Assert.Equal(link, result);
        }


        [Fact]
        public async Task GetLinkByShortUrlAsync_ShortUrl_ReturnsExistingItem()
        {
            // Arrange
            var links = new[]
            {
                new Link
                {
                    ShortUrl = "abc",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                },
                new Link
                {
                    ShortUrl = "def",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                }
            };

            var linksRepository = await GetRepositoryWithMockedData(links);

            // Act
            var result = await linksRepository.GetLinkByShortUrlAsync("def");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteLinkByIdAsync_RemoveLinkById()
        {
            // Arrange
            int id = 1;
            var links = new[]
            {
                new Link
                {
                    Id = 1,
                    ShortUrl = "abc",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                },
                new Link
                {
                    Id = 2,
                    ShortUrl = "def",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                }
            };

            var linksRepository = await GetRepositoryWithMockedData(links);

            // Act
            await linksRepository.DeleteLinkByIdAsync(id);

            // Assert
            await linksRepository.SaveAsync();
            var result = (await linksRepository.GetAllLinksAsync()).FirstOrDefault(x => x.Id == id);
            Assert.Null(result);
        }
        [Fact]
        public async Task DeleteAllLinks_RemoveAllLinksInDatabase()
        {
            // Arrange
            var links = new[]
            {
                new Link
                {
                    Id = 1,
                    ShortUrl = "abc",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                },
                new Link
                {
                    Id = 2,
                    ShortUrl = "def",
                    FullUrl = "https://example.com",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Username"
                }
            };

            var linksRepository = await GetRepositoryWithMockedData(links);

            // Act
            linksRepository.DeleteAllLinks();
            await linksRepository.SaveAsync();

            // Assert
            var result = await linksRepository.GetAllLinksAsync();
            Assert.Equal(0, result.Count());
        }


        private async Task<ILinkRepository> GetRepositoryWithMockedData(Link[] links)
        {
            var repo = new LinkRepository(new UrlShortenerDbContext(_dbContextOptions));
            foreach (var item in links)
            {
                await repo.AddLinkAsync(item);
            }
            await repo.SaveAsync();
            return repo;
        }
    }
}
