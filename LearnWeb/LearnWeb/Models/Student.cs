using System.ComponentModel.DataAnnotations;

namespace LearnWeb.Models
{
    public class Student
    {
        public Student()
        {
            StudentsOnCourses = new List<StudentOnCourse>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1950, 2007,
        ErrorMessage = "{0} повинен від {1} до {2}.")]
        public int YearOfBirth { get; set; }

        public virtual ICollection<StudentOnCourse> StudentsOnCourses { get; set; }
    }
}
