namespace TAU.Website.Models.Region;

using Piranha.Extend;
using Piranha.Extend.Fields;

public class ProductsHomeRegion
{
    [Field(Title = "Title")] public TextField Title { get; set; }

    [Field(Title = "Text")] public HtmlField Text { get; set; }

    [Field(Title = "Icon")] public StringField Icon { get; set; }

    [Field(Title = "URL")] public StringField Url { get; set; }
}