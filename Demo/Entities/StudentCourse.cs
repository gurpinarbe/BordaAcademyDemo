namespace Demo.Entities
{
    public class StudentCourse : BaseEntity
    {
        public StudentCourse(int studentId)
        {
            StudentId = studentId;
        }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; }
    }
}
