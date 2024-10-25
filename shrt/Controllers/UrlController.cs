using Microsoft.AspNetCore.Mvc;
using shrt.Dtos.requests;
using shrt.Dtos.response;
using shrt.models;
using shrt.services;

namespace shrt.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UrlController : ControllerBase
{
    private readonly UrlService _urlService;

    public UrlController(UrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpPost]
    public async Task<UrlResponse> ShortenUrl(CreateUrlRequest url)
    {
        return await _urlService.CreateShortUrlAsyn(url);
    }
    
}

