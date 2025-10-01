using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TitanHelpDesk.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Ticket>()
            .Property(t => t.Status)
            .HasConversion<string>();

        modelBuilder
            .Entity<Ticket>()
            .Property(t => t.Priority)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}
