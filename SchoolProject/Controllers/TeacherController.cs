using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller

    { 
        private readonly TeacherRepository _teacherrepository;
        public TeacherController(TeacherRepository teacherrepository)
        {
            _teacherrepository = teacherrepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers=_teacherrepository.GetAllTeacher();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher != null)
            {
                _teacherrepository.create(teacher);
                List<Teacher> teachers = _teacherrepository.GetAllTeacher();
                return View("Index",teachers);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            
        }
        //[HttpPost]
        public ActionResult Delete(int id) 
        {
            if (id > 0)
            {
                _teacherrepository.Delete(id);
                List<Teacher> teachers = _teacherrepository.GetAllTeacher();
                return View("Index", teachers);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

    }
}
