using SchoolProject.Models;
using SchoolProject.Context;
namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _myDbcontext;
        public RoomRepository(MyDbContext myDbContext)
        {
           _myDbcontext = myDbContext;
        }

        public void create(Room room)
        {
            _myDbcontext.Rooms.Add(room);
            _myDbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room=(from roomobj in _myDbcontext.Rooms
                       where roomobj.RoomID == id
                       select roomobj).FirstOrDefault();
            _myDbcontext.Rooms.Remove(room);
            _myDbcontext.SaveChanges();
        }

        public List<Room> GetAllRoom()
        {
            List<Room> room=(from roomobj in _myDbcontext.Rooms 
                       select roomobj).ToList();
            return room;
        }
    }
}
