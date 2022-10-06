using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core.Models;
using RepositoryPattern.Api.Core.Repositories;
using RepositoryPattern.Api.DbContexts;

namespace RepositoryPattern.Api.Persistence.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{

    public CourseRepository(DbContext context) : base(context)
    {

    }
    
    private readonly DbSet<Course> _entities;


    public async Task<IEnumerable<Course>> GetCoursesWithAuthors(int pageIndex = 1, int pageSize = 10)
    {
        return await PlutoContext.Courses
                .Include(a => a.Author)
                .OrderBy(a => a.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetTopSellingCourses(int count)
    {
        return await PlutoContext.Courses
            .OrderByDescending(c => c.IsBeginnerCourse)
            .Take(count)
            .ToListAsync();
    }

    public PlutoContext PlutoContext =>
        Context as PlutoContext;
}
