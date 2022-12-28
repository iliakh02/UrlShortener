using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebAPI.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullUrl { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string ShortUrl { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set;}
    }
}
