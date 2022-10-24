namespace TAU.Website.Models.Region;

using Piranha.Extend;
using Piranha.Extend.Fields;

public class ManagedServicesRegion
{
    [Field(Title = "Title")] public StringField Title { get; set; }

    [Field(Title = "Text")] public HtmlField Text { get; set; }

    [Field(Title = "Icon")] public StringField Icon { get; set; }

    [Field(Title = "URL")] public StringField Url { get; set; }
}