using Demo.Database;
using Demo.Dtos;
using Demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DemoContext _demoContext;
        public CourseController(DemoContext context)
        {
            _demoContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Course> courses = _demoContext.Courses.Include(i => i.Students).ToList();
            List<int> studentIds = courses.SelectMany(i=>i.Students.Select(i=>i.StudentId)).Distinct().ToList();

            List<Student> students = _demoContext.Students.Where(i => studentIds.Contains(i.Id)).ToList();

            List<CourseDto> courseDtos = courses.Select(i => new CourseDto(i, students.Where(s => i.Students.Select(k => k.StudentId).Contains(s.Id)).ToList())).ToList();
            
            return Ok(courseDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Course Course = _demoContext.Courses.FirstOrDefault(i => i.Id == id);

            return Ok(Course);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            Course Course = Course.Create(name);

            _demoContext.Courses.Add(Course);
            _demoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { Course.Id }, new { Course.Id });
        }

        [HttpPut]
        [Route("{id}/addStudent")]
        public async Task<IActionResult> Update(int id, [FromBody] int studentId)
        {
            Course course = _demoContext.Courses.FirstOrDefault(i => i.Id == id);
            course.AddStudent(studentId);

            _demoContext.Courses.Update(course);
            _demoContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Course course = _demoContext.Courses.FirstOrDefault(i => i.Id == id);

            _demoContext.Courses.Remove(course);
            _demoContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}/soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Course course = _demoContext.Courses.FirstOrDefault(i => i.Id == id);
            course.Delete();

            _demoContext.Courses.Update(course);
            _demoContext.SaveChanges();

            return NoContent();
        }
    }
}