using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class Student
    {
        private int id_student;
        private string name;
        private string group;
        private int id_room;
        private DateTime dataIn;

        public int Id_student { get => id_student; set => id_student = value; }
        public string Name { get => name; set => name = value; }
        public string Group { get => group; set => group = value; }
        public int Id_room { get => id_room; set => id_room = value; }
        public DateTime DataIn { get => dataIn; set => dataIn = value; }

        public Student()
        {
            id_student = -1;
            name = string.Empty;
            group = string.Empty;
            id_room = -1;
            dataIn = DateTime.MinValue;
        }
        public Student(string name, string group, int id_room, DateTime dataIn)
        {
            this.name = name;
            this.group = group;
            this.id_room = id_room;
            this.dataIn = dataIn;
        }
        public Student(int id_student, string name, string group, int id_room, DateTime dataIn)
        {
            this.id_student = id_student;
            this.name = name;
            this.group = group;
            this.id_room = id_room;
            this.dataIn = dataIn;
        }
    }
}
