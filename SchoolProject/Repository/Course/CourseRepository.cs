using SchoolProject.Context;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDbContext _myDbcontext;
        public CourseRepository(MyDbContext myDbcontext)
        {
            _myDbcontext = myDbcontext;
        }
        
        

        public void Delete(int id)
        {
            Course course=(from courseobj in _myDbcontext.Courses
                       where courseobj.CourseId == id
                       select courseobj).FirstOrDefault();
            _myDbcontext.Courses.Remove(course);
            _myDbcontext.SaveChanges();
        }

        public List<Course> GetAllCourse()
        {
            List<Course> course = (from courseobj in _myDbcontext.Courses
                                   select courseobj).ToList();
            return course;

        }

        

        public void Create(Course course)
        {
            _myDbcontext.Courses.Add(course);
            _myDbcontext.SaveChanges();

        }

    }
}
