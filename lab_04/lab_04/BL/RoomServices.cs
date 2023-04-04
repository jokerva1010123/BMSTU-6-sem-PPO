using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
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
            if (this.iroomDB.getRoom(room.Id_room.Value).Id_room == null)
                this.iroomDB.addRoom(room);
            else
            {
                //error
            }
        }
        public Room getRoom(int id_room)
        {
            return this.IroomDB.getRoom(id_room);
        }
        public void deleteRoom(int id_room)
        {
            if (this.IroomDB.getRoom(id_room).Id_room != null)
                this.IroomDB.deleteRoom(id_room);
            else
            {
                //error
            }
        }
        public List<Room> getAllRoom()
        {
            return this.IroomDB.getAllRoom();
        }
    }
}
