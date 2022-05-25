using System.ComponentModel.DataAnnotations;

namespace LearnWeb.Models
{
    public class StudentOnCourse
    {
        public int Id { get; set; }
        [Range(0, 100,
        ErrorMessage = "{0} повинен від {1} до {2}.")]
        public int Progress { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
