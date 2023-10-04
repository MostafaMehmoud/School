using SchoolProject.Context;
using SchoolProject.Models;



namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
       // private readonly MyDbContext _MyDbContext;
        private readonly MyDbContext _MyDbcontext;

        public StudentRepository(MyDbContext myDbConext)
        {
            _MyDbcontext = myDbConext;
        }
        public void Create(Student student)
        {
            _MyDbcontext.Students.Add(student);
            _MyDbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = (from stysobj in _MyDbcontext.Students
                              where stysobj.StudentId == id
                              select stysobj).FirstOrDefault();
            _MyDbcontext.Students.Remove(student);
            _MyDbcontext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            try
            {

                List<Student> students = (from stdsObj in _MyDbcontext.Students
                                          select stdsObj).ToList();
                return students;

            }
            catch (Exception ex)
            {
                string error=ex.Message;
                return null;

            }
        }

        public void Register(int studentId, int courseId)
        {
            _MyDbcontext.StudentCourses.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId

            });
            _MyDbcontext.SaveChanges();
        }
    }
}
