using System.ComponentModel.DataAnnotations;
using Piranha.Extend;

namespace TAU.Website.Models;

[BlockType(Name = "Newsletter", Icon = "fa fa-newspaper", Category = "Content")]
public class NewsPaperBlock : Block
{
    [Required] public string Email { get; set; }

    public string Token { get; set; }
}