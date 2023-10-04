using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _myDbContext;
        public TeacherRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

         public void create(Teacher teacher)
        {
            _myDbContext.Teachers.Add(teacher);
            _myDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           Teacher teacher=(from teacherobj in _myDbContext.Teachers
                            where teacherobj.TeacherId==id
                            select teacherobj).FirstOrDefault();
            _myDbContext.Teachers.Remove(teacher);
            _myDbContext.SaveChanges();
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> teacher=(from teacherobj in _myDbContext.Teachers select teacherobj).ToList();
            return teacher;
        }
    }
}
