
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

    public async Task<bool> DeleteUrlAsync(string shortUrl)
    {
        var urlData = await _context.Urls.FirstOrDefaultAsync(
            url => url.ShortUrl == shortUrl);

        if (urlData != null) 
        {
            _context.Urls.Remove(urlData);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public Task<string?> OriginalUrlAsync(string url)
    {
        throw new NotImplementedException();
    }

    //public async Task<string?> OriginalUrlAsync(string shortUrl)
    //{
    //    var url = await _context.Urls.SingleOrDefaultAsync(
    //        u => u.ShortUrl == shortUrl);

    //    if (url == null)
    //    {
    //        return null;
    //    }

    //    url.NumberOfClicks += 1;
    //    await _context.SaveChangesAsync();

    //    return url.LongUrl;
    //}

    public async Task<Url?> UrLAnalticsAsync(string shortUrl)
    {
        var urlData = await _context.Urls.SingleOrDefaultAsync(
            url => url.ShortUrl == shortUrl);

        if (urlData == null)
        {
            return null;
        }
        return urlData;
    }
}
