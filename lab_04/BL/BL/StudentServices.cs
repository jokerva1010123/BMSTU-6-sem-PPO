﻿using Models;
using Error;
using InterfaceDB;

namespace BL
{
    public class StudentServices
    {
        private readonly IRoomDB iroomDB;
        private IStudentDB istudentDB;
        public IStudentDB IstudentDB { get => istudentDB; set => istudentDB = value; }
        public StudentServices(IStudentDB istudentDB, IRoomDB roomDB)
        {
            this.IstudentDB = istudentDB;
            this.iroomDB = roomDB;
        }
        public void addStudent(string name, string group, string studentCode, int id_room, DateTime dateTime, int id_user)
        {
            if (id_user < 1)
                throw new UserNotFoundException();
            if (name.Length < 1 || group.Length < 1 || studentCode.Length < 1)
                throw new AddStudentErrorException();
            List<Student> allStudent = this.istudentDB.getAllStudent();
            foreach (Student student in allStudent)
                if (student.StudentCode == studentCode)
                    throw new AddStudentErrorException();
            this.istudentDB.addStudent(new Student(name, group, studentCode, id_room, dateTime, id_user));
        }
        public int getIdStudentFromCode(string studentCode)
        {
            int result = -1;
            List<Student> allStudent = this.istudentDB.getAllStudent();
            foreach (Student student in allStudent)
            {
                if (student.StudentCode == studentCode)
                {
                    result = student.Id_student;
                    break;
                }
            }
            if (result == -1)
                throw new StudentNotFoundException();
            else
                return result;
        }
        public int getRoomStudent(int id_student)
        {
            if (id_student < 0)
                throw new StudentNotFoundException();
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            return student.Id_room;
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            Student? newStudent = new Student(id_student, student.Name, newGroup, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.changeStudent(id_student, newStudent);
            student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            if (student.Group != newGroup)
                throw new ChangeStudentGroupErrorException();
        }
        public void changeStudentName(int id_student, string newName)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            Student? newStudent = new Student(id_student, newName, student.Group, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.changeStudent(id_student, newStudent);
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            if (student.Id_room != -1)
                throw new StudentInRoomException();
            Room? room = this.iroomDB.getRoom(id_room);
            if (room == null)
                throw new RoomNotFoundException();
            this.istudentDB.transferStudent(id_student, id_room);
        }
        public void returnRoomStudent(int id_student)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            if (student.Id_room <= 0)
                throw new StudentNotInRoomException();
            this.istudentDB.returnRoom(id_student);
        }
        public Student getStudent(int id_student)
        {
            if (id_student < 1)
                throw new StudentNotFoundException();
            Student? student = this.istudentDB.getStudent(id_student);
            if (student != null)
                return student;
            else
                throw new StudentNotFoundException();
        }
        public List<Student> getAllStudent()
        {
            return this.IstudentDB.getAllStudent();
        }
    }
}
