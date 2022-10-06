using RepositoryPattern.Api.Core.Models;

namespace RepositoryPattern.Api.Core.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorWithCourses(int id);
}
