namespace TAU.Website.Models.Custom_Blocks;

using System.ComponentModel.DataAnnotations;
using Piranha.Extend;
using Piranha.Extend.Fields;

[BlockType(Name = "WhitePaper", Icon = "", Category = "Content", Component = "whitePaper-block")]
public class WhitePaperViewModel : Block
{
    [Required] public string Company { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Position { get; set; }
    [Required] public string Email { get; set; }
    public string Phone { get; set; }
    public string Token { get; set; }

    public TextField Body { get; set; }
}