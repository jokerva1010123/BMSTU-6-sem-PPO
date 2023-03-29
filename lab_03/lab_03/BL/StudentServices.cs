using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class StudentServices
    {
        private IStudentDB istudentDB;
        public IStudentDB IstudentDB { get => istudentDB; set => istudentDB = value; }
        public StudentServices(IStudentDB istudentDB)
        {
            this.IstudentDB = istudentDB;
        }
        public void addStudent(string name, string group, int id_room, DateTime dateTime)
        {
            this.IstudentDB.addStudent(new Student(name, group, id_room, dateTime));
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            this.IstudentDB.changeStudentGroup(id_student, newGroup);
        }
        public void changeStudentName(int id_student, string newName)
        {
            this.IstudentDB.changeStudetName(id_student, newName);
        }
        public void changeRoomStudent(int id_student, int id_room)
        {
            this.IstudentDB.changeRoomStudent(id_student, id_room);
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
            Student student = this.IstudentDB.getStudent(id_student);
            if (student != null)
            {
                this.IstudentDB.deleteStudent(id_student);
            }
        }
    }
}
