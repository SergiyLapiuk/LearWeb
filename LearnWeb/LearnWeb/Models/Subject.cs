using System.ComponentModel.DataAnnotations;


namespace LearnWeb.Models
{
    public class Subject
    {
        public Subject()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
