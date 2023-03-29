using System;
using System.Collections.Generic;
using System.Linq;
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
            this.IroomDB.addRoom(room);
        }
        public Room getRoom(int id_room)
        {
            return this.IroomDB.getRoom(id_room);
        }

        public void deleteRoom(int id_room)
        {
            Room room = this.IroomDB.getRoom(id_room);
            if (room != null)
            {
                this.IroomDB.deleteRoom(id_room);
            }
        }
        public List<Room> getAllRoom()
        {
            return this.IroomDB.getAllRoom();
        }
        /*public List<Thing> getThingInRoom(int id_room)
        {
            return this.IroomDB.getAllThing(id_room);
        }*/
    }
}
