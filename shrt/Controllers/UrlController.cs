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

    public UrlController(UrlService urlService, UserManager<IdentityUser> userManager)
    {
        _urlService = urlService;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> ShortenUrl(CreateUrlRequest url)
    {
        var result = await _urlService.AddUrlAsync(url);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);

    }
}


