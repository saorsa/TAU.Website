using System.ComponentModel.DataAnnotations;

namespace TAU.Website.Data.Entities;

public class Newsletter
{
    [Key] public Guid Id { get; set; }

    public string Email { get; set; }
}