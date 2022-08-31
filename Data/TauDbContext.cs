using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website.Data;

using Microsoft.EntityFrameworkCore;
using TAU.Website.Data.Entities;

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