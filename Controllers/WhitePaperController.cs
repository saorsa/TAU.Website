namespace TAU.Website.Controllers;

using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models.Custom_Blocks;
using TAU.Website.Services;

public class WhitePaperController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;
    private readonly GoogleReCaptchaService _googleReCaptchaService;

    public WhitePaperController(IApi api, IModelLoader loader, GoogleReCaptchaService googleReCaptchaService)
    {
        _api = api;
        _loader = loader;
        _googleReCaptchaService = googleReCaptchaService;
    }

    [HttpPost]
    public async Task<IActionResult> PostWhitePaper(WhitePaper whitePaper)
    {
        var googleReCaptchaResult = await this._googleReCaptchaService.Verify(whitePaper.Token);
        if (googleReCaptchaResult)
        {
            return Ok(whitePaper);
        }

        return BadRequest();
    }
}