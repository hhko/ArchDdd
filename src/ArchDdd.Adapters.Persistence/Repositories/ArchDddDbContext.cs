using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Repositories;

public sealed class ArchDddDbContext : DbContext
{
    public ArchDddDbContext(DbContextOptions options)
        : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    //}
}
