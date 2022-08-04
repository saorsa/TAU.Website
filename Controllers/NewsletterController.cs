
namespace TAU.Website.Controllers;

using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models.Custom_Blocks;
using TAU.Website.Services;

public class NewsletterController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;
    private readonly GoogleReCaptchaService _googleReCaptchaService;
    private readonly INewsletterService _newsletterService;

    public NewsletterController(IApi api, IModelLoader loader, GoogleReCaptchaService googleReCaptchaService, INewsletterService newsletterService )
    {
        _api = api;
        _loader = loader;
        _googleReCaptchaService = googleReCaptchaService;
        _newsletterService = newsletterService;
    }

    [HttpPost]
    public async Task<IActionResult> PostNewsletter(NewsletterViewModel newsletterViewModel)
    {
        var googleReCaptchaResult = await this._googleReCaptchaService.Verify(newsletterViewModel.Token);
        if (googleReCaptchaResult)
        {
            newsletterViewModel = await this._newsletterService.CreateNewsletterAsync(newsletterViewModel);
            return Ok(newsletterViewModel);
        }
        return BadRequest();
    }
}