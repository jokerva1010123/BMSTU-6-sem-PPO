using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class StudentServices
    {
        private readonly IRoomDB roomDB;
        private IStudentDB istudentDB;
        public IStudentDB IstudentDB { get => istudentDB; set => istudentDB = value; }
        public StudentServices(IStudentDB istudentDB, IRoomDB roomDB)
        {
            this.IstudentDB = istudentDB;
            this.roomDB = roomDB;
        }
        public void addStudent(string name, string group, int id_room, DateTime dateTime)
        {
            if (roomDB.getRoom(id_room).Id_room != null)
                this.IstudentDB.addStudent(new Student(name, group, id_room, dateTime));
            else
            {
                // error
            }
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            if (istudentDB.getStudent(id_student).Id_student != -1)
                this.istudentDB.changeStudentGroup(id_student, newGroup);
            else
            {
                //error
            }
        }
        public void changeStudentName(int id_student, string newName)
        {
            if (istudentDB.getStudent(id_student).Id_student != -1)
                this.IstudentDB.changeStudetName(id_student, newName);
            else
            {
                //error
            }
        }
        public void changeRoomStudent(int id_student, int id_room)
        {
            if (istudentDB.getStudent(id_student).Id_student != -1 && roomDB.getRoom(id_room).Id_room != null)
                this.IstudentDB.changeRoomStudent(id_student, id_room);
            else
            {
                //error
            }
        }
        public Student getStudent(int id_student)
        {
            return this.IstudentDB.getStudent(id_student);
        }
        public List<Student> getAllStudent()
        {
            return this.IstudentDB.getAllStudent();
        }
        public void deleteStudent(int id_student)
        {
            if (this.IstudentDB.getStudent(id_student) != null)
                this.IstudentDB.deleteStudent(id_student);
            else
            {
                //error
            }
        }
    }
}
