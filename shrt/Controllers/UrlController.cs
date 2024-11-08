using Microsoft.AspNetCore.Mvc;
using shrt.Dtos.requests;
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
    public async Task<IActionResult> ShortenUrl(CreateUrlRequest url)
    {
        var result = await _urlService.CreateShortUrlAsyn(url);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);

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

    [HttpGet("{shortUrl}/analytics")]
    public async Task<IActionResult> UrlAnalytics(string shortUrl)
    {
        var urlAnalytic = await _urlService.UrlAnaltic(shortUrl);

        if (urlAnalytic == null)
        {
            return NotFound("Analytics for url not found");
        }
        return Ok(urlAnalytic);
    }

    [HttpDelete("{shortUrl}")]
    public async Task<IActionResult> DeleteUrl(string shortUrl)
    {
        await _urlService.DeleteUrl(shortUrl);
        return NoContent();
    }
}

