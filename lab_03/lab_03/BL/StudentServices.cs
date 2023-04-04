using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (name.Length < 1 || group.Length < 1)
                throw new AddStudentErrorException();
            this.istudentDB.addStudent(new Student(name, group, id_room, dateTime));
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            Student student = this.istudentDB.getStudent(id_student);
            if (student.Id_student == -1)
                throw new StudentNotFoundException();
            this.istudentDB.changeStudentGroup(id_student, newGroup);
        }    
        public void changeStudentName(int id_student, string newName)
        {
            Student student = this.istudentDB.getStudent(id_student);
            if (student.Id_student == -1)
                throw new StudentNotFoundException();
            this.istudentDB.changeStudetName(id_student, newName);
        }
        public void deleteStudent(int id_student)
        {
            if (id_student < 1)
                throw new StudentNotFoundException();
            if (this.IstudentDB.getStudent(id_student).Id_student == -1)
            {
                throw new StudentNotFoundException();
                            }
            else
            {
                this.IstudentDB.deleteStudent(id_student);
            }
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            if (istudentDB.getStudent(id_student).Id_student == -1)
                throw new StudentNotFoundException();
            else 
                if (roomDB.getRoom(id_room).Id_room == null)
                    throw new RoomNotFoundException();
                else 
                    this.IstudentDB.setRoomStudent(id_student, id_room);
        }
        public Student getStudent(int id_student)
        {
            if (id_student < 1)
                throw new StudentNotFoundException();
            Student student = this.istudentDB.getStudent(id_student);
           // Console.WriteLine(student.Id_student);
            if (student.Id_student != -1)
                return student;

            else
            { throw new StudentNotFoundException();
              
            }
        }
        public List<Student> getAllStudent()
        {
            return this.IstudentDB.getAllStudent();
        }
        
    }
}
