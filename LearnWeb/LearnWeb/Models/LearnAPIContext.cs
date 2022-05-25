using Microsoft.EntityFrameworkCore;

namespace LearnWeb.Models
{
    public class LearnAPIContext: DbContext
    {
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentOnCourse> StudentsOnCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public LearnAPIContext(DbContextOptions<LearnAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
