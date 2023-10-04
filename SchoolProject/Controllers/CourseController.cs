using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherrepository;
        public CourseController(CourseRepository courseRepository,TeacherRepository teacherRepository)
        {
            _courseRepository=courseRepository;
            _teacherrepository=teacherRepository;
        }
        [HttpGet]
        public ActionResult Index() 
        {
            List<Course> courses = _courseRepository.GetAllCourse();
            return View(courses); 
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Teacher> teachers = _teacherrepository.GetAllTeacher();
            return View(teachers);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                List<Course> courses = _courseRepository.GetAllCourse();
                _courseRepository.Create(course);
                return View("Index",courses);
            }
            else
            {
                return RedirectToAction("Index");
            }
        
        }
        public ActionResult Delete(int id)
        {
            if(id > 0)
            {
                List<Course> courses = _courseRepository.GetAllCourse();
                _courseRepository.Delete(id);
                return View("Index", courses);

            }else { return RedirectToAction("Index"); } 
        }
        
        
    }
}
