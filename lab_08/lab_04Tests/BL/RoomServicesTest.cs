using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Error;
using Models;
using BL;

namespace Tests.BL
{
    public class TestRoomServices : IRoomDB
    {
        public List<Room> rooms;
        public TestRoomServices(List<Room> rooms)
        {
            this.rooms = rooms;
        }
        public void addRoom(Room room)
        {
            int N = this.rooms.Count;
            this.rooms.Add(new Room(N + 1, room.Number, room.RoomTypes));
        }
        public void deleteRoom(int id_room)
        {
            List<Room> newRoom = new List<Room>();
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room != id_room)
                    newRoom.Add(tmpRoom);
            this.rooms = newRoom;
        }
        public Room? getRoom(int id_room)
        {
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room == id_room)
                    return tmpRoom;
            return null;
        }
        public List<Room> getAllRoom()
        {
            return this.rooms;
        }
    }
}
