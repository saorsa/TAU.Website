namespace TAU.Website.Data;

using Microsoft.EntityFrameworkCore;
using TAU.Website.Data.Entities;

public class TauDbContext : DbContext
{
    public TauDbContext(DbContextOptions<TauDbContext> options) : base(options)
    {
    }

    public DbSet<Newsletter> Newsletters { get; set; }

    public DbSet<WhitePaper> WhitePapers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}