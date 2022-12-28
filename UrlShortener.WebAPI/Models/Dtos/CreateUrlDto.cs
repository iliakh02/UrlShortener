using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebAPI.Models.Dtos
{
    public class CreateUrlDto
    {
        [Required]
        [MinLength(10)]
        public string FullUrl { get; set; }
    }
}
