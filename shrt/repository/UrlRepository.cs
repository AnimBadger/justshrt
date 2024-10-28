
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
        var url = await _context.Urls.
            Where(u => u.ShortUrl == shortUrl)
            .Select(u => u.LongUrl)
            .FirstOrDefaultAsync();

        return url;
    }
}
