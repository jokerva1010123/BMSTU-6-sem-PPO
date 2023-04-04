using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class RoomServices
    {
        private IRoomDB iroomDB;
        public IRoomDB IroomDB { get => iroomDB; set => iroomDB = value; }
        public RoomServices(IRoomDB iroomDB)
        {
            this.IroomDB = iroomDB;
        }
        public void addRoom(Room room)
        {
            List<Room> allRoom = this.iroomDB.getAllRoom();
            foreach (Room tmproom in allRoom)
                if (tmproom.Number == room.Number)
                    throw new RoomExistsException();
            this.iroomDB.addRoom(room);
        }
        public Room getRoom(int id_room)
        {
            Room room = this.IroomDB.getRoom(id_room);
            if (room.Id_room == null)
                throw new RoomNotFoundException();
            else
                return room;
        }
        public void deleteRoom(int id_room)
        {
            Room room = this.IroomDB.getRoom(id_room);
            if (room.Id_room == null)
                throw new RoomNotFoundException();
            else
            {
                this.IroomDB.deleteRoom(id_room);
                room = this.iroomDB.getRoom(id_room);
                if (room.Id_room != null)
                    throw new DeleteRoomErrorException();
            }
        }
        public List<Room> getAllRoom()
        {
            return this.IroomDB.getAllRoom();
        }
    }
}
