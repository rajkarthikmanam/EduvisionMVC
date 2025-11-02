using Microsoft.EntityFrameworkCore;
using EduvisionMvc.Models;

namespace EduvisionMvc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<CourseInstructor> CourseInstructors => Set<CourseInstructor>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Student>().Property(x => x.Gpa).HasPrecision(3, 2);

        b.Entity<Enrollment>()
          .HasOne(e => e.Student).WithMany(s => s.Enrollments)
          .HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);

        b.Entity<Enrollment>()
          .HasOne(e => e.Course).WithMany(c => c.Enrollments)
          .HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);

        b.Entity<CourseInstructor>()
          .HasKey(ci => new { ci.CourseId, ci.InstructorId });

        b.Entity<CourseInstructor>()
          .HasOne(ci => ci.Course).WithMany(c => c.CourseInstructors)
          .HasForeignKey(ci => ci.CourseId);

        b.Entity<CourseInstructor>()
          .HasOne(ci => ci.Instructor).WithMany(i => i.CourseInstructors)
          .HasForeignKey(ci => ci.InstructorId);
    }
}
