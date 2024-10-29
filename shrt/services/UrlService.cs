using shrt.Dtos.requests;
using shrt.Dtos.response;
using shrt.models;
using shrt.repository;

namespace shrt.services;

public class UrlService
{
    private readonly IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<UrlResponse?> CreateShortUrlAsyn(CreateUrlRequest url)
    {
        string longUrl = url.Url;

        if (!longUrl.StartsWith("http://") || !longUrl.StartsWith("https://"))
        {
            longUrl = "https://" + longUrl;
        }

        bool isValid = await IsValidUrlAysnc(longUrl);
        if (!isValid) 
        {
            return null;
        }

        Guid guid = Guid.NewGuid();

        string shortUrlExtension = guid.ToString()[^7..];
        var urlBody = new Url
        {
            ShortUrl = shortUrlExtension,
            LongUrl = longUrl
        };

        await _urlRepository.AddUrlAsync(urlBody);

        var response = new UrlResponse
        {
            Url = shortUrlExtension
        };
        return response;
    }

    public async Task<string?> RedirectToOriginal(string shortUrl)
    {
        var originalUrl = await _urlRepository.OriginalUrlAsync(shortUrl);

        return originalUrl;
    }

    public async Task<bool> IsValidUrlAysnc(string url)
    {
        if (!IsValidUrlFormat(url))
        {
            return false;
        }
         
        using var httpclient = new HttpClient();

        try
        {
            var response = await httpclient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            return response.IsSuccessStatusCode;
        }
        catch 
        {
            return false;
        }

    }

    public bool IsValidUrlFormat(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri ? uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
