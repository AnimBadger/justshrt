namespace DefaultNamespace;

public class Url
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LngUrl { get; set; }
    public string ShortUrl { get; set; }
    public int NumberOfClicks { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
}