using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnWeb.Models;

namespace LearnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentOnCoursesController : ControllerBase
    {
        private readonly LearnAPIContext _context;

        public StudentOnCoursesController(LearnAPIContext context)
        {
            _context = context;
        }

        // GET: api/StudentOnCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentOnCourse>>> GetStudentsOnCourses()
        {
          if (_context.StudentsOnCourses == null)
          {
              return NotFound();
          }
            return await _context.StudentsOnCourses.ToListAsync();
        }

        // GET: api/StudentOnCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentOnCourse>> GetStudentOnCourse(int id)
        {
          if (_context.StudentsOnCourses == null)
          {
              return NotFound();
          }
            var studentOnCourse = await _context.StudentsOnCourses.FindAsync(id);

            if (studentOnCourse == null)
            {
                return NotFound();
            }

            return studentOnCourse;
        }

        // PUT: api/StudentOnCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentOnCourse(int id, StudentOnCourse studentOnCourse)
        {
            if (id != studentOnCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentOnCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentOnCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentOnCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentOnCourse>> PostStudentOnCourse(StudentOnCourse studentOnCourse)
        {
          if (_context.StudentsOnCourses == null)
          {
              return Problem("Entity set 'LearnAPIContext.StudentsOnCourses'  is null.");
          }
            if (!IsUnique(studentOnCourse.CourseId, studentOnCourse.StudentId))
                return Problem("Entity already exists.");
            _context.StudentsOnCourses.Add(studentOnCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentOnCourse", new { id = studentOnCourse.Id }, studentOnCourse);
        }

        bool IsUnique(int courseId, int studentId)
        {
            var q = (from studentOnCourse in _context.StudentsOnCourses
                     where studentOnCourse.CourseId == courseId && studentOnCourse.StudentId == studentId
                     select studentOnCourse).ToList();
            if (q.Count == 0) { return true; }
            return false;
        }

        // DELETE: api/StudentOnCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentOnCourse(int id)
        {
            if (_context.StudentsOnCourses == null)
            {
                return NotFound();
            }
            var studentOnCourse = await _context.StudentsOnCourses.FindAsync(id);
            if (studentOnCourse == null)
            {
                return NotFound();
            }

            _context.StudentsOnCourses.Remove(studentOnCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentOnCourseExists(int id)
        {
            return (_context.StudentsOnCourses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
