using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomRepository _roomRepository;
        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms=_roomRepository.GetAllRoom();
            return View(rooms);
        }
        [HttpGet]
        public ActionResult create() 
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult create(Room room) 
        {
            if (room != null) 
            { 
                _roomRepository.create(room);
                List<Room> rooms = _roomRepository.GetAllRoom();
                return View("Index",rooms);
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
                _roomRepository.Delete(id);
                List<Room> rooms = _roomRepository.GetAllRoom();
                return View("Index", rooms);
            }
            else { 
                return RedirectToAction("Index"); 
                  }
            
        }
    }
}
