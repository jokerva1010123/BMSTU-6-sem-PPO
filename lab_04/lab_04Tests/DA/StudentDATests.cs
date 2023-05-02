using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Error;
using Models;
using DA;
using BL;

namespace Tests.DA
{
    [TestClass()]
    public class StudentDATests
    {
        [TestMethod()]
        public void getStudentTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            Student student = studentServices.getStudent(1);

            Assert.AreEqual(student.Name, "Alex");
        }
        [TestMethod()]
        public void getStudentFailTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            Assert.ThrowsException<StudentNotFoundException>(() => studentServices.getStudent(999));
        }
        [TestMethod()]
        public void getStudentIdFromCodeTest() 
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            int id_student = studentServices.getIdStudentFromCode("1234321"); 
            Assert.AreEqual(id_student, 1);
        }
        [TestMethod()]
        public void getAllStudentTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            List<Student> allStudent = studentServices.getAllStudent();
            string sql = studentDA.getStrGetAllStudent();
            int count = 0;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, studentDA.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    count++;
            reader.Close();
            Assert.AreEqual(count, allStudent.Count);
        }
    }
}