using UrlShortener.WebAPI.Services.Abstract;
using UrlShortener.WebAPI.Services;

namespace UrlShortener.UnitTests
{
    public class UrlShortenerServiceTests
    {
        private readonly IUrlShortenerService _urlShortenerService;
        private const string  _url = "https://www.google.com/";
        private readonly string _shortUrl;
        public UrlShortenerServiceTests()
        {
            _urlShortenerService = new UrlShortenerService();
            _shortUrl = _urlShortenerService.GenerateShortURL(_url);
        }

        [Fact]
        public void GenerateShortURL_ValidUrl_ReturnsNotNullOrEmptyValue()
        {
            // Arrange

            // Act
            var result = _urlShortenerService.GenerateShortURL(_url);

            //Assert
            Assert.True(!string.IsNullOrEmpty(result));
        }


        [Fact]
        public void GenerateShortURL_ValidUrl_ReturnsTheSameValue()
        {
            // Arrange

            // Act
            var result = _urlShortenerService.GenerateShortURL(_url);

            //Assert
            Assert.Equal(result, _shortUrl);
        }
    }
}