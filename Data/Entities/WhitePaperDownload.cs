using System.ComponentModel.DataAnnotations;

namespace TAU.Website.Data.Entities;

public class WhitePaperDownload
{
    [Key] public Guid Id { get; set; }

    public string Company { get; set; }

    public string Name { get; set; }

    public string Position { get; set; }

    public string ContentUrl { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}