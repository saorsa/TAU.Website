using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Region;

public class NewsRegion
{
    [Field(Title = "Background image")] public ImageField BackgroundImage { get; set; }

    [Field(Title = "Title")] public StringField Title { get; set; }

    [Field(Title = "Content")] public TextField Content { get; set; }

    [Field(Title = "Link")] public StringField ReadMoreLink { get; set; }
}