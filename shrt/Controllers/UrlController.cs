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
    [HttpGet("{shortUrl}")] 
    public async Task<IActionResult> RedirectUrl(string shortUrl)
    {
        var originalUrl = await _urlService.RedirectToOriginal(shortUrl);
        if (originalUrl == null)
        {
            return NotFound("Url not found");
        }
        return Redirect(originalUrl);
    }
}

