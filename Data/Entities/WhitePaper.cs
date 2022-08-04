namespace TAU.Website.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class WhitePaper
{
    [Key] public Guid Id { get; set; }

    public string Company { get; set; }

    public string Name { get; set; }

    public string Position { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}