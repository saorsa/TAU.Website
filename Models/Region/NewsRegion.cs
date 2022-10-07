namespace TAU.Website.Models.Region;

using Piranha.Extend;
using Piranha.Extend.Fields;

public class NewsRegion
{
    [Field(Title = "Image")] public ImageField PrimaryImage { get; set; }

    [Field(Title = "Title")] public TextField Title { get; set; }

    [Field(Title = "Content")] public TextField Contents { get; set; }
}