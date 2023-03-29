using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class Room
    {
        private int id_room;
        private int number;
        private string roomType;

        public int Id_room { get => id_room; set => id_room = value; }
        public int Number { get => number; set => number = value; }
        public string RoomType { get => roomType; set => roomType = value; }
        public Room()
        {
            this.id_room = -1;
            this.number = -1;
            this.roomType = "";
        }
        public Room(int id_room, int number, string roomType)
        {
            this.id_room = id_room;
            this.number = number;
            this.roomType = roomType;
        }
        public Room(int number, string roomType)
        {
            this.number = number;
            this.roomType = roomType;
        }
    }
}
