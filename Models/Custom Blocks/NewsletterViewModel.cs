namespace TAU.Website.Models.Custom_Blocks;

using Piranha.Extend;

[BlockType(Name = "Newsletter", Icon = "fas fa-paragraph", Category = "Content", Component = "Newsletter")]
public class NewsletterViewModel : Block
{
    public string Email { get; set; }

    public string Token { get; set; }
}