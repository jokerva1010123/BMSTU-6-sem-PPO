using System;
using System.Collections.Generic;
using BL;
using Models;

namespace GUIManage
{
    public class GUIStudentManager
    {
        private StudentServices studentServices;
        private UserServices userServices;
        public GUIStudentManager(StudentServices studentServices, UserServices userServices) 
        {
            this.studentServices = studentServices;
            this.userServices = userServices;
        }
        public void addNewStudent(string name, string group, string studentCode, int id_room, string login, string password)
        {
            this.userServices.addUser(login, password, Levels.STUDENT);
            int id = this.userServices.getIdUser(login);
            DateTime now = DateTime.Today;
            this.studentServices.addStudent(name, group, studentCode, id_room, now, id);
        }
        public List<Student> getAllStudent()
        {
            return this.studentServices.getAllStudent();
        }
        public void changeStudentGroup(string code, string newGroup)
        {
            int id = this.studentServices.getIdStudentFromCode(code);
            this.studentServices.changeStudentGroup(id, newGroup);
        }
        public void changeStudentName(string code, string newName)
        {
            int id_student = this.studentServices.getIdStudentFromCode(code);
            this.studentServices.changeStudentName(id_student, newName);
        }
        public string getStudentCodeFromIdUser(int id_user)
        {
            string result = string.Empty;
            List<Student> allStudent = this.studentServices.getAllStudent();
            foreach (Student student in allStudent)
                if(student.Id_user == id_user)
                {
                    result = student.StudentCode;
                    break;
                }
            return result;
        }
        public void setRoom(string studentCode, int id_room)
        {
            int id_student = this.studentServices.getIdStudentFromCode(studentCode);
            this.studentServices.setRoomStudent(id_student, id_room);
        }
        public void returnRoom(string studentCode)
        {
            int id_student = this.studentServices.getIdStudentFromCode(studentCode);
            this.studentServices.returnRoomStudent(id_student);
        }
    }
}
