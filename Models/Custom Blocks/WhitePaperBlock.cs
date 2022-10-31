using System.ComponentModel.DataAnnotations;
using Piranha.Extend;
using Piranha.Extend.Fields;

namespace TAU.Website.Models.Custom_Blocks;

[BlockType(Name = "WhitePaper", Icon = "", Category = "Content", Component = "whitePaper-block")]
public class WhitePaperBlock : Block
{
    [Required] public StringField ContentUrl { get; set; }
    public string Company { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Token { get; set; }
}