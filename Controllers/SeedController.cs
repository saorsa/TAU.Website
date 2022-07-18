namespace TAU.Website.Controllers;

using TAU.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;

public class SeedController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;
    private readonly ISeedService _seedService;

    public SeedController(IApi api, IModelLoader loader, ISeedService seedService)
    {
        _api = api;
        _loader = loader;
        _seedService = seedService;
    }

    [Route("/customSeed")]
    public async Task<IActionResult> Seed()
    {
        await this._seedService.SeedData();
        return Ok();
    }
}