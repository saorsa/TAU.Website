using System.Diagnostics.CodeAnalysis;

namespace TAU.Website.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class PageWhitePaper
{
    [Key] 
    public Guid Id { get; set; }

    [NotNull]
    public string WhitePaperUrl { get; set; }
    [NotNull]
    public Guid PageId { get; set; }
}