using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourse();
        public void Create(Course course);
        public void Delete(int id);
    }
}
