using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeacher();
        public void create(Teacher teacher);
        public void Delete(int id);
    }
}
