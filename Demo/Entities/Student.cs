namespace Demo.Entities
{
    public class Student : BaseEntity
    {
        private Student(string firstName, string lastName, int? studentNumber = null)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int? StudentNumber { get; private set; }

        public static Student Create(string firstName, string lastName, int? studentNumber = null)
        {
            return new Student(firstName, lastName, studentNumber);
        }

        public void Update(string firstName, string lastName)
        {
            FirstName=firstName;
            LastName = lastName;
        }

        public void Delete()
        {
            RecordStatus = 0;
        }
    }
}
