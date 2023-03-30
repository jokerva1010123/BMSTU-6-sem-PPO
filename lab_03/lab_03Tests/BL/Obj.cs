using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03.Tests
{
    static public class Obj
    {
        public static List<Room> rooms = new List<Room>
        {
            new Room(1, 528, RoomType.StudentRoom),
            new Room(2, 428, RoomType.StudentRoom),
            new Room(3, 101, RoomType.Storage)
        };
        public static List<Thing> things = new List<Thing>
        {
            new Thing(1, 228, "Chair", 1, 1),
            new Thing(2, 1234, "Table", 2, 2),
            new Thing(3, 321, "Chair", 3, -1)
        };
    }
}
