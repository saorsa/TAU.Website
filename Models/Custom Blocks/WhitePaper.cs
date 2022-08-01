using Piranha.Extend;

namespace TAU.Website.Models.Custom_Blocks;

[BlockType(Name = "WhitePaper", Icon = "", Category = "Content", Component = "WhitePaper")]
public class WhitePaper : Block
{
    public string Company { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}