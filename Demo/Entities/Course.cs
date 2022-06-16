namespace Demo.Entities
{
    public class Course : BaseEntity
    {
        private readonly List<StudentCourse> _students;

        private Course(string name)
        {
            Name = name;
            _students = new();
        }

        public string Name { get; set; }
        public IReadOnlyList<StudentCourse> Students => _students.AsReadOnly();


        public static Course Create(string name)
        {
            return new Course(name);
        }

        public void AddStudent(int studentId)
        {
            _students.Add(new StudentCourse(studentId));
        }

        public void Delete()
        {
            RecordStatus = 0;
        }
    }
}
