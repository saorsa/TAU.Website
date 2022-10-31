using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

namespace TAU.Website.Models.Pages;

[PageType(Title = "Products page")]
[ContentTypeRoute(Title = "ProductsPage", Route = "/products")]
public class ProductsPage : Page<StandardPage>
{
    [Region(ListTitle = "Products")] public IList<ProductsRegion> Products { get; set; }
}