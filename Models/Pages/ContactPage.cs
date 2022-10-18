namespace TAU.Website.Models.Pages;

using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using TAU.Website.Models.Region;

[PageType(Title = "Contact page")]
[ContentTypeRoute(Title = "ContactPage", Route = "/contact")]
public class ContactPage : Page<StandardPage>
{
    [Region(Title = "Contacts")] public ContactRegion Contacts { get; set; }
}