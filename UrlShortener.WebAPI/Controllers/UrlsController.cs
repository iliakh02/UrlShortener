﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.WebAPI.DAL;
using UrlShortener.WebAPI.Models;
using UrlShortener.WebAPI.Services;
using UrlShortener.WebAPI.Services.Abstract;

namespace UrlShortener.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        [Route("getShortLink")]
        public string GetShortLink()
        {
            Console.WriteLine("--------Call get method!!!");
            var x = _urlShortenerService.GenerateShortURL("https://www.linkedin.com/in/mrfesfsgdgesst/");
            return x;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Link>> GetAllUrls()
        {
            return await _linkRepository.GetAllLinksAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IEnumerable<Link>> GetUrlInfo()
        {
            return await _linkRepository.GetAllLinksAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateNew([FromBody]string fullUrl)
        {
            string shortUrl = _urlShortenerService.GenerateShortURL(fullUrl);
            var newLink = new Link
            {
                FullUrl = fullUrl,
                ShortUrl = shortUrl,
                CreatedDate = DateTime.Now,
                CreatedBy = "Secret User"
            }; 
            await _linkRepository.AddLinkAsync(newLink);
            await _linkRepository.SaveAsync();
            Ok(shortUrl);
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
        public async Task DeleteUrlById()
        {
            _linkRepository.DeleteAllLinks();
            await _linkRepository.SaveAsync();
            Ok();
        }
    }
}