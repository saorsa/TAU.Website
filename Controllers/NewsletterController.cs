using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models;
using TAU.Website.Services;

namespace TAU.Website.Controllers;

public class NewsletterController : Controller
{
    private readonly IApi _api;
    private readonly GoogleReCaptchaService _googleReCaptchaService;
    private readonly IModelLoader _loader;
    private readonly INewsletterService _newsletterService;

    public NewsletterController(IApi api, IModelLoader loader, GoogleReCaptchaService googleReCaptchaService,
        INewsletterService newsletterService)
    {
        _api = api;
        _loader = loader;
        _googleReCaptchaService = googleReCaptchaService;
        _newsletterService = newsletterService;
    }

    [HttpPost]
    public async Task<IActionResult> PostNewsletter(NewsPaperBlock newsPaperBlock)
    {
        if (ModelState.IsValid)
        {
            var googleReCaptchaResult = await _googleReCaptchaService.Verify(newsPaperBlock.Token);
            if (googleReCaptchaResult)
            {
                newsPaperBlock = await _newsletterService.CreateNewsletterAsync(newsPaperBlock);
                return Ok(newsPaperBlock);
            }
        }

        return BadRequest();
    }
}