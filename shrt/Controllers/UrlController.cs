using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shrt.Dtos.requests;
using shrt.services;

namespace shrt.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UrlController : ControllerBase
{
    private readonly UrlService _urlService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<UrlController> _logger;

    public UrlController(UrlService urlService, UserManager<IdentityUser> userManager, ILogger<UrlController> logger)
    {
        _urlService = urlService;
        _userManager = userManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> ShortenUrl(CreateUrlRequest url)
    {
        _logger.LogInformation("Request received to create short url");
        var result = await _urlService.AddUrlAsync(url);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);

    }
}


