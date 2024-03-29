﻿using Microsoft.AspNetCore.Mvc;
using UrlShortener.WebAPI.DAL;
using UrlShortener.WebAPI.Models;
using UrlShortener.WebAPI.Models.Dtos;
using UrlShortener.WebAPI.Services.Abstract;

namespace UrlShortener.WebAPI.Controllers
{
    [Route("api/urls")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;
        private readonly ILinkRepository _linkRepository;

        public UrlsController(IUrlShortenerService urlShortenerService, ILinkRepository linkRepository)
        {
            _urlShortenerService = urlShortenerService;
            _linkRepository = linkRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Link>> GetAllUrls()
        {
            return await _linkRepository.GetAllLinksAsync();
        }

        [HttpGet]
        [Route("info/{shortUrl}")]
        public async Task<Link> GetUrlInfo(string shortUrl)
        {
            return await _linkRepository.GetLinkByShortUrlAsync(shortUrl);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUrlDto urlDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var urls = await _linkRepository.GetAllLinksAsync();
            if (urls.FirstOrDefault(x => x.FullUrl == urlDto.FullUrl) != null)
                return BadRequest();
            string shortUrl = _urlShortenerService.GenerateShortURL(urlDto.FullUrl);
            var newLink = new Link
            {
                FullUrl = urlDto.FullUrl,
                ShortUrl = shortUrl,
                CreatedDate = DateTime.Now,
                CreatedBy = "Secret User"
            };
            await _linkRepository.AddLinkAsync(newLink);
            await _linkRepository.SaveAsync();
            return Ok(shortUrl);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task DeleteUrlById(int id)
        {
            await _linkRepository.DeleteLinkByIdAsync(id);
            await _linkRepository.SaveAsync();
            Ok();
        }

        [HttpDelete]
        [Route("deleteAll")]
        public async Task DeleteAll()
        {
            _linkRepository.DeleteAllLinks();
            await _linkRepository.SaveAsync();
            Ok();
        }

        [HttpGet]
        [Route("/{shortUrl}")]
        public async Task<IActionResult> GetUrl(string shortUrl)
        {
            if (String.IsNullOrEmpty(shortUrl))
                return BadRequest();

            var link = await _linkRepository.GetLinkByShortUrlAsync(shortUrl);

            if (link == null)
                return NotFound();

            return RedirectPermanent(link.FullUrl);
        }
    }
}
