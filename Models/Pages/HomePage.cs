using Piranha.Extend.Fields;

namespace TAU.Website.Models.Pages;

using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Models;
using TAU.Website.Models.Region;

[PageType(Title = "Home page")]
[ContentTypeRoute(Title = "HomePage", Route = "/homepage")]
public class HomePage : Page<StandardPage>
{
    [Region(ListTitle = "Carousel")] public IList<NewsRegion> Carousel { get; set; }

    [Region(Title = "Products")] public IList<ProductsRegion> Products { get; set; }

    [Region(Title = "Free Text")] public TextContentRegion HomePageText { get; set; }
    
}