using Piranha.Extend;

namespace TAU.Website.Models.Custom_Blocks;

[BlockType(Name = "Newsletter", Icon = "fas fa-paragraph", Category = "Content", Component = "Newsletter")]
public class Newsletter : Block
{
    public string Email { get; set; }
}