using Microsoft.EntityFrameworkCore;
using PolicyCancellationTracker.Models;

namespace PolicyCancellationTracker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}
    public DbSet<CancellationRecord> CancellationRecords { get; set; }
}