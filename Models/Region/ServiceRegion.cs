using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Region;

public class ServiceRegion
{
    [Field(Title = "Header")] public TextField Header { get; set; }

    [Field(Title = "Text")] public HtmlField Text { get; set; }

    [Field(Title = "Image")] public ImageField Image { get; set; }

    [Field(Title = "URL")] public StringField Url { get; set; }
}