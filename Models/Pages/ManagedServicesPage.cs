using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

namespace TAU.Website.Models.Pages;

[PageType(Title = "Managed Services page")]
[ContentTypeRoute(Title = "ManagedServicesPage", Route = "/managedservices")]
public class ManagedServicesPage : Page<StandardPage>
{
    [Region(ListTitle = "Managed Services")]
    public IList<ManagedServicesRegion> ManagedServices { get; set; }
}