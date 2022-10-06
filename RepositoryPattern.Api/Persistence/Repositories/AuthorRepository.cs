using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.Models;
using RepositoryPattern.Api.Core.Repositories;
using RepositoryPattern.Api.DbContexts;

namespace RepositoryPattern.Api.Persistence.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(DbContext context) : base(context)
    {
    }

    public async Task<Author> GetAuthorWithCourses(int id)
    {
        return await PlutoContext?
            .Authors?
            .Include(a => a.Courses)?
            .SingleOrDefaultAsync(a => a.Id == id);
    }

    public PlutoContext PlutoContext => Context as PlutoContext;
}
