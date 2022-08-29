namespace TAU.Website.Models.Custom_Blocks;

using System.ComponentModel.DataAnnotations;

public class WhitePaperUrlModel
{
    [Required] public string Url { get; set; }
}