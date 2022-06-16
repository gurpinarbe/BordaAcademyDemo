using Demo.Entities;

namespace Demo.Dtos
{
    public class StudentDto
    {
        public StudentDto(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            StudentNumber = student.StudentNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? StudentNumber { get; set; }
    }
}
