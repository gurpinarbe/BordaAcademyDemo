namespace Demo.Entities
{
    public class Course : BaseEntity
    {
        private Course(string name)
        {
            Name = name;
            Students = new();
        }

        public string Name { get; set; }
        public List<StudentCourse> Students { get; set; }

        public static Course Create(string name)
        {
            return new Course(name);
        }

        public void AddStudent(int studentId)
        {
            Students.Add(new StudentCourse(studentId));
        }

        public void Delete()
        {
            RecordStatus = 0;
        }
    }
}
