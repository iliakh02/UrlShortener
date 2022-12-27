namespace UrlShortener.WebAPI.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set;}
    }
}
