using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Region;

public class TextContentRegion
{
    [Field(Title = "Title")] public TextField Title { get; set; }

    [Field(Title = "Body")] public HtmlField Body { get; set; }
}