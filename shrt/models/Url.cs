namespace shrt.models;

public class Url
{
    public int Id { get; set; }
    public string? LongUrl { get; set; }
    public string? ShortUrl { get; set; }
    public int NumberOfClicks { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}