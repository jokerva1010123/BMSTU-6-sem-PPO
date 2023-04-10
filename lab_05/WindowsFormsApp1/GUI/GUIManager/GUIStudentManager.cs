using System.Collections.Generic;

namespace lab_05
{
    public class GUIStudentManager
    {
        private StudentServices studentServices;
        private UserServices userServices;
        private RoomServices roomServices;
        private ThingServices thingsServices;
        public GUIStudentManager(StudentServices studentServices, UserServices userServices, RoomServices roomServices, ThingServices thingServices) 
        {
            this.studentServices = studentServices;
            this.userServices = userServices;
            this.roomServices = roomServices;
            this.thingsServices = thingServices;
        }
        public void addNewStudent(string name, string group, string studentCode, string login, string password)
        {
            this.userServices.addUser(login, password, Levels.STUDENT);
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
            int id = this.studentServices.getIdStudentFromCode(code);
            this.studentServices.changeStudentName(id, newName);
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
    }
}
