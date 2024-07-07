using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace OneToOne_01;

// Required one-to-one
// https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one#required-one-to-one

public sealed class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogHeader> BlogHeaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=blogging.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // 1. Required one-to-one

        builder.Entity<Blog>()
            .HasOne(blog => blog.Header)
            .WithOne(blogHeader => blogHeader.Blog)
            .HasForeignKey<BlogHeader>(blogHeader => blogHeader.BlogId)
            .IsRequired();
    }
}

// Principal (parent)
public sealed class Blog
{
    public int Id { get; set; }
    public BlogHeader? Header { get; set; } // Reference navigation to dependent
}

// Dependent (child)
public sealed class BlogHeader
{
    public int Id { get; set; }
    public int BlogId { get; set; } // Required foreign key property
    public Blog Blog { get; set; } = null!; // Required reference navigation to principal
}