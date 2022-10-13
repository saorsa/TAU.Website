namespace TAU.Website.Models.Pages;

using Piranha.Models;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using TAU.Website.Models.Region;

[PageType(Title = "Products page")]
[ContentTypeRoute(Title = "ProductsPage", Route = "/productspage")]
public class ProductsPage : Page<StandardPage>
{
    [Region(ListTitle = "Products")] public IList<ProductsRegion> Products { get; set; }

}