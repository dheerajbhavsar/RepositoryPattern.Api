using RepositoryPattern.Api.Core;
using RepositoryPattern.Api.Core.Repositories;
using RepositoryPattern.Api.DbContexts;
using RepositoryPattern.Api.Persistence.Repositories;

namespace RepositoryPattern.Api.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PlutoContext _context;

    public ICourseRepository Courses { get; private set; }

    public IAuthorRepository Authors { get; private set; }

    public UnitOfWork(PlutoContext context)
    {
        _context = context;
        Courses = new CourseRepository(_context);
        Authors = new AuthorRepository(_context);
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
