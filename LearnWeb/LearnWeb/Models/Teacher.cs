using System.ComponentModel.DataAnnotations;

namespace LearnWeb.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new List<Course>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Degree { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
