using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        public void Register(int StudentId, int CourseId);
        public void Delete(int id);
    }
}
