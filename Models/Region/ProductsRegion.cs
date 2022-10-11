namespace TAU.Website.Models.Region;

using Piranha.Extend;
using Piranha.Extend.Fields;

public class ProductsRegion
{
    [Field(Title = "Title")] public TextField Title { get; set; }

    [Field(Title = "Text")] public HtmlField Text { get; set; }
}