using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly IHostingEnvironment _environment;
        public StudentController(StudentRepository studentRepository, CourseRepository courseRepository,IHostingEnvironment environment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _environment = environment;
        }

        [HttpGet]
       public ActionResult Index()
        {
           List<Student> students = _studentRepository.GetAllStudents(); 
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student,IFormFile StudentPhoto)
        {
            Guid guid=new Guid();
            var wwroot = _environment.WebRootPath + "/Studentpicture/";
            string fullPath=System.IO.Path.Combine(wwroot,guid + StudentPhoto.FileName);
            var FileStream=new FileStream(fullPath,FileMode.Create);
            StudentPhoto.CopyTo(FileStream);

            if (student != null)
            {
                student.PhotoName=guid +StudentPhoto.FileName;
                _studentRepository.Create(student);
                List<Student> students = _studentRepository.GetAllStudents();
                return View("Index",students);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _studentRepository.Delete(id);
                List<Student> students = _studentRepository.GetAllStudents();
                return View("Index", students);


            }

            return View();
        }
        [HttpGet]
        public ActionResult Register() 
        { StudentCourseVM data = new StudentCourseVM();
            data.Students = _studentRepository.GetAllStudents();
            data.Courses = _courseRepository.GetAllCourse();
            return View(data); 
        }
        [HttpPost]
        public ActionResult Register(int StudentId,int CourseId)
        {
            _studentRepository.Register(StudentId, CourseId);   
            return RedirectToAction("Register");
        }
    }
}
