
namespace TAU.Website.Models.Custom_Blocks;

using Piranha.Extend;
using System.ComponentModel.DataAnnotations;

[BlockType(Name = "Newsletter", Icon = "fas fa-paragraph", Category = "Content")]
public class NewsletterViewModel : Block
{
    [Required]
    public string Email { get; set; }

    public string Token { get; set; }
}