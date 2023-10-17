using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Error;
using Models;
using BL;
using System.Security.Cryptography.X509Certificates;

namespace Tests.BL
{
    public class TestStudentServices : IStudentDB
    {
        private List<Student> students;
        public TestStudentServices(List<Student> students)
        {
            this.students = students;
        }
        public void addStudent(Student student)
        {
            int N = this.students.Count;
            this.students.Add(new Student(student.Name, student.Group, student.StudentCode, student.Id_room, student.DataIn, student.Id_user));
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            List<Student> newStudent = new List<Student>();
            foreach (Student student in this.students)
            {
                if (student.Id_student == id_student)
                    student.Group = newGroup;
                newStudent.Add(student);
            }
            this.students = newStudent;
        }
        public void changeStudentName(int id_student, string newName)
        {
            List<Student> newStudent = new List<Student>();
            foreach (Student student in this.students)
            {
                if (student.Id_student == id_student)
                    student.Name = newName;
                newStudent.Add(student);
            }
            this.students = newStudent;
        }
        public void deleteStudent(int id_student)
        {
            List<Student> newStudent = new List<Student>();
            foreach (Student student in this.students)
            {
                if (student.Id_student == id_student)
                    student.Id_room = -1;
                newStudent.Add(student);
            }
            this.students = newStudent;
        }
        public Student? getStudent(int id_student)
        {
            foreach (Student student in this.students)
                if (student.Id_student == id_student)
                    return student;
            return null;
        }
        public List<Student> getAllStudent()
        {
            return this.students;
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            List<Student> newStudent = new List<Student>();
            foreach (Student student in this.students)
            {
                if (student.Id_student == id_student)
                    student.Id_room = id_room;
                newStudent.Add(student);
            }
            this.students = newStudent;
        }
        public int getIdStudentFromCode(string code)
        {
            foreach (Student student in this.students)
                if (student.StudentCode == code)
                    return student.Id_student;
            return -1;
        }
        public void returnRoom(int id_studnt)
        {
            foreach (Student student in this.students)
                if (student.Id_student == id_studnt)
                    student.Id_room = -1;
        }
        public void transferStudent(int id_student, int id_room)
        {
            foreach(Student student in this.students)
                if(student.Id_student == id_student)
                    student.Id_room = id_room;
        }
        public void changeStudent(int id_student, Student newStudent)
        {
            List<Student> newstudent = new List<Student>();
            foreach(Student student in this.students)
            {
                if(student.Id_student == id_student)
                    newstudent.Add(newStudent);
                else newstudent.Add(student);
            }
            this.students = newstudent;
        }
    }
}
