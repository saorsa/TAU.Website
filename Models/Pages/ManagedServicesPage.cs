namespace TAU.Website.Models.Pages;
using Piranha.Models;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using TAU.Website.Models.Region;

[PageType(Title = "Managed Services page")]
[ContentTypeRoute(Title = "ManagedServicesPage", Route = "/managedservices")]
public class ManagedServicesPage : Page<StandardPage>
{
    
    [Region(ListTitle = "Managed Services")] public IList<ManagedServicesRegion> ManagedServices { get; set; }
}