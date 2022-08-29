namespace TAU.Website.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class Settings
{
    [Key] public Guid Id { get; set; }

    public string WhitePaperUrl { get; set; }
}