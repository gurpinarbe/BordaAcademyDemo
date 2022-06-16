using Demo.Entities;

namespace Demo.Dtos
{
    public class CourseDto
    {
        public CourseDto(Course course, List<Student> students)
        {
            CourseId = course.Id;
            Name = course.Name;
            Students = students.Select(student => new StudentDto(student)).ToList();
        }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
