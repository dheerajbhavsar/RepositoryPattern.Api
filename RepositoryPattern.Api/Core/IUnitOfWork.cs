using RepositoryPattern.Api.Core.Repositories;

namespace RepositoryPattern.Api.Core;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }

    Task<int> Complete();
}
