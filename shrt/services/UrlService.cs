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

    public async Task<UrlResponse> CreateShortUrlAsyn(CreateUrlRequest url)
    {
        Guid guid = Guid.NewGuid();

        string shortUrlExtension = guid.ToString().Substring(guid.ToString().Length - 7);
        var urlBody = new Url
        {
            ShortUrl = shortUrlExtension,
            LongUrl = url.Url
        };

        await _urlRepository.AddUrlAsync(urlBody);

        var response = new UrlResponse
        {
            Url = shortUrlExtension
        };
        return response;
    }
}
