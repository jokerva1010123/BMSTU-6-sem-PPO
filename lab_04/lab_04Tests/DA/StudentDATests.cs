using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace lab_04.Tests
{
    [TestClass()]
    public class StudentDATests
    {
        [TestMethod()]
        public void getStudentTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            Student student = studentServices.getStudent(1);

            Assert.AreEqual(student.Name, "Alex");
        }
        [TestMethod()]
        public void getStudentFailTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            Assert.ThrowsException<StudentNotFoundException>(() => studentServices.getStudent(999));
        }
        [TestMethod()]
        public void addStudentTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            studentServices.addStudent("Bob", "IU7-63", "123321", 2, DateTime.Parse("Jan 04 2022"));

            NpgsqlCommand command = new NpgsqlCommand(studentDA.getStrGetStudent(2), studentDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Student student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)));
            reader.Close();

            Assert.AreEqual(student.Name, "Bob");
            Assert.AreEqual(student.Group, "IU7-63");
        }
        [TestMethod()]
        public void getStudentIdFromCodeTest() 
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            int id_student = studentServices.getIdStudentFromCode("1234321");
            Assert.AreEqual(id_student, 1);
        }
        [TestMethod()]
        public void getAllStudentTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            List<Student> allStudent = studentServices.getAllStudent();
            Assert.AreEqual(2, allStudent.Count);
        }
    }
}