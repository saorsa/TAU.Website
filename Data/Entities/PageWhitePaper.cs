using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TAU.Website.Data.Entities;

public class PageWhitePaper
{
    [Key] public Guid Id { get; set; }

    [NotNull] public string WhitePaperUrl { get; set; }

    [NotNull] public Guid PageId { get; set; }
}