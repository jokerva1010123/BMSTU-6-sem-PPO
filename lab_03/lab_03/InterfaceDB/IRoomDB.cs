using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public interface IRoomDB
    {
        void addRoom(Room room);
        Room getRoom(int id_room);
        void deleteRoom(int id_room);
        List<Room> getAllRoom();
        //virtual List<Thing> getAllThing(int id_room){}
    }
}
