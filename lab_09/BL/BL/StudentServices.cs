using InterfaceDB;
using Models;
using Error;
using NLog;
using NLog.Fluent;

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
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (id_user < 1)
                throw new UserNotFoundException();
            if (name.Length < 1 || group.Length < 1 || studentCode.Length < 1)
            {
                log.Info("User adds new student unsuccessfully.");
                throw new AddStudentErrorException();                
            }
            List<Student> allStudent = this.istudentDB.getAllStudent();
            foreach (Student student in allStudent)
                if (student.StudentCode == studentCode)
                {
                    log.Info("User adds new student unsuccessfully.");
                    throw new AddStudentErrorException();                     
                }
            this.istudentDB.addStudent(new Student(name, group, studentCode, id_room, dateTime, id_user));
            log.Info("User adds new student successfully.");
        }
        public int getIdStudentFromCode(string studentCode)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
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
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
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
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
            {
                log.Info("User changes student's group unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Student? newStudent = new Student(id_student, student.Name, newGroup, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.changeStudent(id_student, newStudent);
            student = this.istudentDB.getStudent(id_student);
            if (student == null)
            {
                log.Info("User changes student's group unsuccessfully.");
                throw new StudentNotFoundException();
            }
            if (student.Group != newGroup)
            {
                log.Info("User changes student's group unsuccessfully.");
                throw new ChangeStudentGroupErrorException();
            }
            log.Info("User changes student's group successfully.");
        }
        public void changeStudentName(int id_student, string newName)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            Student? newStudent = new Student(id_student, newName, student.Group, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.changeStudent(id_student, newStudent);
            student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            if (student.Name != newName)
                throw new ChangeStudentNameErrorException();
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
            {
                log.Info("User sets student's room unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Room? room = this.iroomDB.getRoom(id_room);
            if (room == null)
            {
                log.Info("User sets student's room unsuccessfully.");
                throw new RoomNotFoundException();
            }
            this.istudentDB.transferStudent(id_student, id_room);
            log.Info("User sets student's room successfully.");
        }
        public Student getStudent(int id_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (id_student < 1)
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Student? student = this.istudentDB.getStudent(id_student);
            if (student != null)
            {
                log.Info("User views student's information successfully.");
                return student;
            }
            else
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
        }
        public List<Student> getAllStudent()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all students successfully.");
            return this.IstudentDB.getAllStudent();
        }
        public void deleteStudent(int id_student)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            this.istudentDB.deleteStudent(id_student);
        }
        public void returnRoomStudent(int id_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
            {
                log.Info("User gets student's room unsuccessfully.");
                throw new StudentNotFoundException();
            }
            if (student.Id_room <= 0)
            {
                log.Info("User gets student's room unsuccessfully.");
                throw new StudentNotInRoomException();
            }
            this.istudentDB.returnRoom(id_student);
            log.Info("User gets student's room successfully.");
        }
    }
}
