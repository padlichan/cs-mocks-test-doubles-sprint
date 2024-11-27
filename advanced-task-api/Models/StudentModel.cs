namespace StudentApp.Models
{
    public interface IStudentModel
    {
        public List<Student> FetchStudents();
        public Student? FetchStudentById(int id);
    }
    public class StudentModel : IStudentModel
    {
        private List<Student> _students = new List<Student>
            {
                new Student { Id = 1, Name = "Ann" },
                new Student { Id = 2, Name = "Beryl" },
                new Student { Id = 3, Name = "Carol" }
            };
        public List<Student> FetchStudents() //returns all students
        { return _students; }
        public Student? FetchStudentById(int id) //returns student with given id
        {
            foreach (Student student in _students)
            {
                if (student.Id == id) { return student; };

            }
            return null;
        }
    }
}
