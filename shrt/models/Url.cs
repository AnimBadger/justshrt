using Microsoft.AspNetCore.Identity;

namespace shrt.models;

public class Url
{
    public int Id { get; set; }
    public string? LongUrl { get; set; }
    public string? ShortUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? UserId { get; set; }
    public IdentityUser? User { get; set; }
}