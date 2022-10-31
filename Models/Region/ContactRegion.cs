using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Region;

public class ContactRegion
{
    [Field(Title = "Our Address")] public StringField Address { get; set; }

    [Field(Title = "Email Us")] public StringField Email { get; set; }

    [Field(Title = "Call Us")] public StringField Phone { get; set; }
}