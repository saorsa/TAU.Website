using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

namespace TAU.Website.Models.Pages;

[PageType(Title = "Service page")]
[ContentTypeRoute(Title = "ServicePage", Route = "/services")]
public class ServicePage : Page<StandardPage>
{
    [Region(ListTitle = "Services")] public IList<ServiceRegion> Services { get; set; }
}