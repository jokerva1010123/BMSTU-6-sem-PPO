using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class Thing
    {
        private int id_thing;
        private int code;
        private string type;
        private int id_room;
        private int? id_student;
        public int Id_thing { get => id_thing; set => id_thing = value; }
        public int Code { get => code; set => code = value; }
        public string Type { get => type; set => type = value; }
        public int Id_room { get => id_room; set => id_room = value; }
        public int? Id_student { get => id_student; set => id_student = value; }
        public Thing(int code, string type, int id_room, int? id_student)
        {
            this.code = code;
            this.type = type;
            this.id_student = id_student;
        }
        public Thing(int id_thing, int code, string type, int id_room, int? id_student)
        {
            this.id_thing = id_thing;
            this.code = code;
            this.type = type;
            this.id_room = id_room;
            this.id_student = id_student;
        }
    }
}
