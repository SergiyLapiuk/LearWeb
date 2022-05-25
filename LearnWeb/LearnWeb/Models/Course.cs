using System.ComponentModel.DataAnnotations;

namespace LearnWeb.Models
{
    public class Course
    {
        public Course()
        {
            StudentsOnCourses = new List<StudentOnCourse>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Info { get; set; }

        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<StudentOnCourse> StudentsOnCourses { get; set; }
    }
}
