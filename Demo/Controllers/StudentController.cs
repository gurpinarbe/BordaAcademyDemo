using Demo.Database;
using Demo.Entities;
using Demo.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DemoContext _demoContext;
        public StudentController(DemoContext context)
        {
            _demoContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Student> students = _demoContext.Students.ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Student? student = _demoContext.Students.FirstOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentRequest request)
        {
            Student student = Student.Create(request.FirstName, request.LastName);

            _demoContext.Students.Add(student);

            await _demoContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { student.Id }, new { student.Id });
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentRequest request)
        {
            Student? student = _demoContext.Students.FirstOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            student.Update(request.FirstName, request.LastName);

            await _demoContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Student? student = _demoContext.Students.FirstOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            _demoContext.Students.Remove(student);

            await _demoContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}/soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Student? student = _demoContext.Students.FirstOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            student.Delete();

            await _demoContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
