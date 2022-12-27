using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.WebAPI.Services.Abstract;

namespace UrlShortener.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IUrlShortenerService UrlShortenerService { get; }

        public HomeController(IUrlShortenerService urlShortenerService)
        {
            UrlShortenerService = urlShortenerService;
        }

        [HttpGet]
        [Route("getShortLink")]
        public string GetShortLink(string longLink)
        {
            return UrlShortenerService.GenerateShortURL(longLink);
        }
    }
}
