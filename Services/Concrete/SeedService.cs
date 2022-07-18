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

        var orderedContentPages = new List<List<string>>();
        var currentMenu = new List<string>();
        var pageOrderNumber = string.Empty;
        foreach (var page in arrayAllPages)
        {
            pageOrderNumber = page.Trim().Split(" ")[0].Split(".")[0];
            if (currentMenu.Count == 0)
            {
                currentMenu.Add(page.Trim());
                continue;
            }

            if (currentMenu.FirstOrDefault().Trim().Split(" ")[0].Split(".")[0].Contains(pageOrderNumber))
            {
                currentMenu.Add(page.Trim());
            }
            else
            {
                orderedContentPages.Add(currentMenu);
                currentMenu = new List<string> {page};
                if (arrayAllPages.Last() == page)
                {
                    orderedContentPages.Add(currentMenu);
                }
            }
        }

        var site = await _api.Sites.GetDefaultAsync();

        foreach (var pageSection in orderedContentPages)
        {
            var currentParent = pageSection.FirstOrDefault();
            var sortOrder = 0;
            var parentsIds = new List<StandardPage>();

            foreach (var page in pageSection)
            {
                var pageSelector = page.Split(" ")[0].Split(".").ToList();

                var docsPage = await StandardPage.CreateAsync(_api);
                docsPage.Id = Guid.NewGuid();
                docsPage.SiteId = site.Id;
                docsPage.SortOrder = sortOrder++;
                docsPage.Title = page.Trim();
                docsPage.NavigationTitle = page.Trim();
                docsPage.Published = DateTime.Now;
                docsPage.Slug = new Random().Next().ToString();

                if (pageSelector.Count > 1)
                {
                    docsPage.ParentId = parentsIds[pageSelector.Count - 2].Id;
                }

                if (pageSelector.Count == parentsIds.Count)
                {
                    parentsIds[parentsIds.Count - 1].Id = docsPage.Id;
                }
                else if (pageSelector.Count < parentsIds.Count)
                {
                    parentsIds.RemoveRange(parentsIds.Count - (parentsIds.Count - pageSelector.Count) - 1, parentsIds.Count - pageSelector.Count);
                    parentsIds[parentsIds.Count - 1].Id = docsPage.Id;
                }
                else
                {
                    parentsIds.Add(docsPage);
                }

                await _api.Pages.SaveAsync(docsPage);
            }
        }
        
        return "done";
    }
}