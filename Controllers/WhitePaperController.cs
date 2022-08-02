using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website.Controllers;

public class WhitePaperController : Controller
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;

    public WhitePaperController(IApi api, IModelLoader loader)
    {
        _api = api;
        _loader = loader;
    }

    [HttpPost]
    public async Task<IActionResult> PostWhitePaper(string company, string name, string position, string email,
        string phone)
    {
        var a = Request;
        return Ok();
    }
}