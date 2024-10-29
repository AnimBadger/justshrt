
using Microsoft.EntityFrameworkCore;
using shrt.Db;
using shrt.models;

namespace shrt.repository;

public class UrlRepository : IUrlRepository
{
    private readonly AppDbContext _context;

    public UrlRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUrlAsync(Url url)
    {
       await _context.AddAsync(url);
        await _context.SaveChangesAsync();
    }

    public async Task<string?> OriginalUrlAsync(string shortUrl)
    {
        var url = await _context.Urls.SingleOrDefaultAsync(
            u => u.ShortUrl == shortUrl);

        if (url == null)
        {
            return null;
        }

        url.NumberOfClicks += 1;
        await _context.SaveChangesAsync();

        return url.LongUrl;
    }
}
