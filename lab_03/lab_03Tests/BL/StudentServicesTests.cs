﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Error;
using Models;
using BL;

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
            this.students.Add(new Student(N + 1, student.Name, student.Group, student.StudentCode, student.Id_room, student.DataIn));
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
                if(student.Id_student == id_student)
                    return student;
            return null;
        }
        public List<Student> getAllStudent()
        {
            return this.students;
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            List <Student> newStudent = new List<Student>();
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
    }
    [TestClass()]
    public class StudentServicesTests
    {
        [TestMethod()]
        public void getStudentTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
            new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
            new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            Student student = studentServices.getStudent(1);

            Assert.AreEqual(student.Name, "Alex");
            Assert.AreEqual(student.Group, "IU7-64");
            Assert.AreEqual(student.DataIn, DateTime.Parse("06-02-2023"));
        }
        [TestMethod()]
        public void getStudentFailTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
            new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
            new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);
            
            Assert.ThrowsException<StudentNotFoundException>(() => studentServices.getStudent(4));
        }
        [TestMethod()]
        public void addStudentTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
            new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
            new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            studentServices.addStudent("Sasha", "IU7-61", "54321234", 1, DateTime.Parse("10-02-2023"));
            Student student = testStudent.getStudent(4);

            Assert.AreEqual(student.Name, "Sasha");
            Assert.AreEqual(student.Group, "IU7-61");
            Assert.AreEqual(student.DataIn, DateTime.Parse("10-02-2023"));
        }
        [TestMethod()]
        public void getAllStudentTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            List<Student> allStudent = studentServices.getAllStudent();
            
            Assert.AreEqual(allStudent.Count, 3);
        }
        [TestMethod()]
        public void deleteStudentTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            studentServices.deleteStudent(1);
            Student student = testStudent.getStudent(1);

            Assert.AreEqual(student.Id_room, -1);
        }
        [TestMethod()]
        public void deleteStudentFailTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            Assert.ThrowsException<StudentNotFoundException>(() => studentServices.deleteStudent(4));
        }
        [TestMethod()]
        public void  changeStudentNameTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            studentServices.changeStudentName(1, "Alexa");
            Student student = testStudent.getStudent(1);

            Assert.AreEqual(student.Name, "Alexa");
        }
        [TestMethod()]
        public void  changeStudentNameFailTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            Assert.ThrowsException<StudentNotFoundException>(() => studentServices.changeStudentName(4, "Alexa"));
            
        }
        [TestMethod()]
        public void changeStudentGroupTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            studentServices.changeStudentGroup(1, "IU7-66");
            Student student = testStudent.getStudent(1);

            Assert.AreEqual(student.Group, "IU7-66");
        }
        [TestMethod()]
        public void changeStudentGroupFailTest()
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023")),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"))
            };
            TestStudentServices testStudent = new TestStudentServices(students);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            StudentServices studentServices = new StudentServices(testStudent, testRoom);

            
            Assert.ThrowsException<StudentNotFoundException>(()=> studentServices.changeStudentGroup(4, "IU7-66"));
        }
    }
}