using Microsoft.EntityFrameworkCore;
using TAU.Website.Data.Entities;

namespace TAU.Website.Data;

public class TauDbContext : DbContext
{
    public TauDbContext(DbContextOptions<TauDbContext> options) : base(options)
    {
    }

    public DbSet<Newsletter> Newsletters { get; set; }

    public DbSet<WhitePaperDownload> WhitePaperDownloads { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}