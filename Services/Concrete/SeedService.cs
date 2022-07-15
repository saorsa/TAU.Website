namespace TAU.Website.Services.Concrete;

using Piranha;
using Piranha.AspNetCore.Services;
using TAU.Website.Models;

public class SeedService : ISeedService
{
    private readonly IApi _api;
    private readonly IModelLoader _loader;

    public SeedService(IApi api, IModelLoader loader)
    {
        _api = api;
        _loader = loader;
    }

    public async Task<string> SeedData(CancellationToken cancellationToken = default)
    {
        var contents = new Dictionary<string, List<string>>();

        using var sr = new StreamReader("wwwroot/Content.txt");
        var allPages = await sr.ReadToEndAsync();
        var arrayAllPages = allPages.Split("\n");

        var site = await _api.Sites.GetDefaultAsync();
        var counter = 1;
        foreach (var page in arrayAllPages)
        {
            var docsPage = await StandardPage.CreateAsync(_api);
            docsPage.Id = Guid.NewGuid();
            docsPage.SiteId = site.Id;
            docsPage.SortOrder = counter++;
            docsPage.Title = page.Trim();
            docsPage.NavigationTitle = page.Trim();
            docsPage.Published = DateTime.Now;
            docsPage.Slug = new Random().Next().ToString();

            await _api.Pages.SaveAsync(docsPage);
        }

        return "done";
    }
}