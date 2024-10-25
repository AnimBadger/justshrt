
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

}
