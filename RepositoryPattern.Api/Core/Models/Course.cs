using System.Diagnostics.Eventing.Reader;

namespace RepositoryPattern.Api.Core.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Level { get; set; }
    public virtual Author Author { get; set; }
    public int AuthorId { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }

    public bool IsBeginnerCourse
    {
        get { return Level == 1; }
    }
}