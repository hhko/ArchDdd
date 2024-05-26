using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Repositories;

public sealed class ArchDddDbContext : DbContext
{
    public ArchDddDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // IEntityTypeConfiguration 모든 클래스
        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
