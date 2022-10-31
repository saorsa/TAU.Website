using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Region;

public class ProductsRegion
{
    [Field(Title = "Heading")] public StringField Heading { get; set; }

    [Field(Title = "Thumbnail text")] public HtmlField ThumbnailText { get; set; }

    [Field(Title = "Full text")] public HtmlField FullText { get; set; }

    [Field(Title = "Image")] public ImageField Image { get; set; }
}