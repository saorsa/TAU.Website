using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website.Controllers;

using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;

public class NewsletterController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;

    public NewsletterController (IApi api, IModelLoader loader)
    {
        _api = api;
        _loader = loader;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostNewsletter(Newsletter newsletter)
    {
        
        return Ok(newsletter);
    }
}