namespace EduvisionMvc.Models;

public class Instructor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName  { get; set; } = "";
    public string Email     { get; set; } = "";
    public List<CourseInstructor> CourseInstructors { get; set; } = new();
}

public class CourseInstructor  // join entity (many-to-many)
{
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
    public Course? Course { get; set; }
    public Instructor? Instructor { get; set; }
}
