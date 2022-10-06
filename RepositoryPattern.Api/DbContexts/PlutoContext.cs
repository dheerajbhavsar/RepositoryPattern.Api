using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.Models;

namespace RepositoryPattern.Api.DbContexts;

public class PlutoContext : DbContext
{
    public PlutoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
