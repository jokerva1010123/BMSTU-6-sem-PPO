﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void addStudentTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            studentServices.addStudent("Bob", "IU7-63", "12311321", 2, DateTime.Parse("Jan 04 2022"), 3);
            int id_student = studentServices.getIdStudentFromCode("12311321");
            NpgsqlCommand command = new NpgsqlCommand(studentDA.getStrGetStudent(id_student), studentDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Student student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)), reader.GetInt32(6));
            reader.Close();

            Assert.AreEqual(student.Name, "Bob");
            Assert.AreEqual(student.Group, "IU7-63");
            studentServices.deleteStudent(id_student);
        }
        [TestMethod()]
        public void deleteStudentTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);

            studentServices.addStudent("Bob", "IU7-63", "12311321", 2, DateTime.Parse("Jan 04 2022"), 3);
            int id_student = studentServices.getIdStudentFromCode("12311321");
            studentServices.deleteStudent(id_student);
            NpgsqlCommand command = new NpgsqlCommand(studentDA.getStrGetStudent(id_student), studentDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
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