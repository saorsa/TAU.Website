namespace TAU.Website.Data.Entities;

using System.ComponentModel.DataAnnotations;

public class Newsletter
{
    [Key] public Guid Id { get; set; }

    public string Email { get; set; }
}