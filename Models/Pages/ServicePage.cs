namespace TAU.Website.Models.Pages;

using Piranha.Models;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using TAU.Website.Models.Region;

[PageType(Title = "Service page")]
[ContentTypeRoute(Title = "ServicePage", Route = "/services")]
public class ServicePage : Page<StandardPage>
{
    [Region(ListTitle = "Services")] public IList<ServiceRegion> Services { get; set; }
}