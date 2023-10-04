using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRoom();
        public void create(Room room);
        public void Delete(int id);
    }
}
