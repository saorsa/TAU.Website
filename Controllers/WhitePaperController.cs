namespace TAU.Website.Controllers;

using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models.Custom_Blocks;
using TAU.Website.Services;

[Route("WhitePaper")]
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
    public async Task<IActionResult> PostWhitePaper(WhitePaperViewModel whitePaperViewModel)
    {
        if (ModelState.IsValid)
        {
            var googleReCaptchaResult = await this._googleReCaptchaService.Verify(whitePaperViewModel.Token);
            if (googleReCaptchaResult)
            {
                await this._whitePaperService.CreateWhitePaperAsync(whitePaperViewModel);
                var whitePaperUrl = await this._whitePaperService.GetWhitePaperUrlAsync();
                return Ok(whitePaperUrl);
            }
        }

        return BadRequest();
    }

    [HttpPost("SaveWhitePaperUrlAsync")]
    public async Task<IActionResult> SaveWhitePaperUrlAsync([FromBody]WhitePaperUrlModel whitePaper)
    {
        if (ModelState.IsValid)
        {
            await this._whitePaperService.SaveWhitePaperUrlAsync(whitePaper);
            return Ok(whitePaper);
        }

        return BadRequest();
    }

    [HttpGet("GetWhitePaperUrlAsync")]
    public async Task<IActionResult> GetWhitePaperUrlAsync()
    {
        var whitePaperUrl = await this._whitePaperService.GetWhitePaperUrlAsync();
        return Ok(Json(whitePaperUrl));
    }
}