using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using UrlShortener.WebAPI.Services.Abstract;

namespace UrlShortener.WebAPI.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public string GenerateShortURL(string url)
        {
            int hash = url.GetHashCode();
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(hash));
        }
    }
}
