using shrt.Db;
using shrt.Dtos.requests;
using shrt.Dtos.response;
using shrt.models;
using shrt.repository;

namespace shrt.services;

public class UrlService : IUrlRepository
{
    private readonly AppDbContext _appDbContext;

    public UrlService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UrlResponse?> AddUrlAsync(CreateUrlRequest url)
    {
        var longUrl = url.Url;
        // validate if url is a valid url
        if (!longUrl.StartsWith("https://") || !longUrl.StartsWith("http://"))
        {
            longUrl = "https://" + longUrl;
        }

        bool isValidUrl = await IsValidUrlAsync(longUrl);
        if (!isValidUrl) 
        {
            return null;
        }

        Guid guid = Guid.NewGuid();

        string shortUrlExtension = guid.ToString()[^7..];
        
        var urlBody = new Url
        {
            ShortUrl = shortUrlExtension,
            LongUrl = longUrl,
            UserId = url.UserId
        };

        await _appDbContext.Urls.AddAsync(urlBody);
        await _appDbContext.SaveChangesAsync();

        var response = new UrlResponse
        {
            Url = shortUrlExtension
        };
        return response;
    }

    public bool IsvalidUrlFormat(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri ? uriResult) && 
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    public async Task<bool> IsValidUrlAsync(string url)
    {
        if (!IsvalidUrlFormat(url))
        {
            return false;
        }

        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    //public async Task<bool> DeleteUrlAsync(string shortUrl)
    //{
    //    var urlData = await _appDbContext.Urls.FirstOrDefaultAsync(
    //        url => url.ShortUrl == shortUrl);
    //    if (urlData != null) 
    //    {
    //        _appDbContext.Urls.Remove(urlData);
    //        await _appDbContext.SaveChangesAsync();
    //        return true;
    //    }
    //    return false;
    //}

    //public async Task<Url?> OriginalUrlAsync(string shortUrl)
    //{
    //    var urlData = await _appDbContext.Urls.SingleOrDefaultAsync(
    //        url => url.ShortUrl == shortUrl);

    //    if (urlData == null)
    //    {
    //        return null;
    //    }
    //    return urlData;
    //}

    //Task<string?> IUrlRepository.OriginalUrlAsync(string url)
    //{
    //    throw new NotImplementedException();
    //}
}
