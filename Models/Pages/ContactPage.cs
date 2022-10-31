using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

namespace TAU.Website.Models.Pages;

[PageType(Title = "Contact page")]
[ContentTypeRoute(Title = "ContactPage", Route = "/contacts")]
public class ContactPage : Page<StandardPage>
{
    [Region(Title = "Contacts")] public ContactRegion Contacts { get; set; }
}