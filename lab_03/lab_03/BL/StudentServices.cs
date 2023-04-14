using InterfaceDB;
using Error;
using Models;

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
        public void addStudent(string name, string group, string studentCode, int id_room, DateTime dateTime)
        {
            if (name.Length < 1 || group.Length < 1 || studentCode.Length < 1)
                throw new AddStudentErrorException();
            this.istudentDB.addStudent(new Student(name, group, studentCode, id_room, dateTime));
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            this.istudentDB.changeStudentGroup(id_student, newGroup);
        }
        public void changeStudentName(int id_student, string newName)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            this.istudentDB.changeStudentName(id_student, newName);
        }
        public void deleteStudent(int id_student)
        {
            if (id_student < 1)
                throw new StudentNotFoundException();
            if (this.IstudentDB.getStudent(id_student) == null)
                throw new StudentNotFoundException();
            else
                this.IstudentDB.deleteStudent(id_student);
        }
        public int getIdStudentFromCode(string studentCode)
        {
            int result = -1;
            List<Student> allStudent = this.istudentDB.getAllStudent();
            foreach (Student student in allStudent)
            {
                if (student.StudentCode == studentCode)
                    result = student.Id_student;
                break;
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
