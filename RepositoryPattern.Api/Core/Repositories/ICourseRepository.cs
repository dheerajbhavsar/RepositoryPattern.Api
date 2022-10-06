using RepositoryPattern.Api.Core.Models;

namespace RepositoryPattern.Api.Core.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> GetTopSellingCourses(int count);

    Task<IEnumerable<Course>> GetCoursesWithAuthors(int pageIndex, int pageSize);
}
