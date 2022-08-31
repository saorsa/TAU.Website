using TAU.Website.Models;

namespace TAU.Website.Controllers;

using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models.Custom_Blocks;
using TAU.Website.Services;

[Route("api/[controller]")]
public class WhitePaperController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;
    private readonly GoogleReCaptchaService _googleReCaptchaService;
    private readonly IWhitePaperService _whitePaperService;

    public WhitePaperController(IApi api,
        IModelLoader loader,
        GoogleReCaptchaService googleReCaptchaService,
        IWhitePaperService whitePaperService)
    {
        _api = api;
        _loader = loader;
        _googleReCaptchaService = googleReCaptchaService;
        _whitePaperService = whitePaperService;
    }

    [HttpPost("PostWhitePaper")]
    public async Task<IActionResult> PostWhitePaper(WhitePaperBlock whitePaperBlock, Guid pageId)
    {
        if (ModelState.IsValid)
        {
            var googleReCaptchaResult = await this._googleReCaptchaService.Verify(whitePaperBlock.Token);
            if (googleReCaptchaResult)
            {
                await this._whitePaperService.CreateWhitePaperDownloadAsync(whitePaperBlock);
                var whitePaperUrl = await this._whitePaperService.GetWhitePaperUrlAsync(pageId, whitePaperBlock.Id);
                return Ok(whitePaperUrl);
            }
        }

        return BadRequest();
    }
}