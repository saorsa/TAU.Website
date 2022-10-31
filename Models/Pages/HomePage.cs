using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

namespace TAU.Website.Models.Pages;

[PageType(Title = "Home page")]
[ContentTypeRoute(Title = "HomePage", Route = "/home")]
public class HomePage : Page<StandardPage>
{
    [Region(ListTitle = "Carousel")] public IList<NewsRegion> Carousel { get; set; }

    [Region(Title = "Products")] public IList<ProductsHomeRegion> Products { get; set; }

    [Region(Title = "Free Text")] public TextContentRegion HomePageText { get; set; }
}