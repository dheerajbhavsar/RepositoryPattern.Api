namespace RepositoryPattern.Api.Core.Models;

public class Author
{
    public Author()
    {
        Courses = new HashSet<Course>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public virtual ICollection<Course> Courses { get; set; }
}
