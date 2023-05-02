using Npgsql;
using System.Data;
using InterfaceDB;
using Error;
using Models;

namespace DA
{
    public class StudentDA : IStudentDB
    {
        private string connectString;
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public StudentDA(ConnectionArgs args)
        {
            this.connectString = args.getString();
            this.Connector = new NpgsqlConnection(this.connectString);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addStudent(Student student)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrAddStudent(student);
            Console.WriteLine(sql);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public int getIdStudentFromCode(string code)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetIdStudent(code);
            int id = -1;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;
        }
        public void changeStudent(int id_student, Student newStudent)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrChangeStudent(id_student, newStudent);
            Console.WriteLine(sql);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public Student? getStudent(int id_student)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetStudent(id_student);
            Student? student = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)), reader.GetInt32(6));
            }
            reader.Close();
            return student;
        }
        public List<Student> getAllStudent()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Student> allStudent = new List<Student>();
            string sql = getStrGetAllStudent();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                      reader.GetInt32(4), DateTime.Parse(reader.GetString(5)), reader.GetInt32(6));
                    allStudent.Add(student);
                }
            }
            reader.Close();
            return allStudent;
        }
        public void returnRoom(int id_student)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrReturnRoom(id_student);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void transferStudent(int id_student, int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrTransferStudent(id_student, id_room);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public string getStrAddStudent(Student student)
        {
            return "insert into Students(name, groupStudent, studentCode, id_room, date, id_user) values ('"
                + student.Name + "', '" + student.Group + "', '" + student.StudentCode + "', " +
                student.Id_room.ToString() + ", '" + student.DataIn.ToString() + "', " + student.Id_user.ToString() + ");";
        }
        public string getStrGetAllStudent()
        {
            return "select * from Students";
        }
        public string getStrGetIdStudent(string code)
        {
            return "select id_student from Students where studentCode = '" + code + "';";
        }
        public string getStrGetStudent(int id_student)
        {
            return "select * from Students where id_student = " + id_student.ToString() + ";";
        }
        public string getStrChangeStudent(int id_student, Student newStudent)
        {
            return "update Students set name = '" + newStudent.Name + "', groupStudent = '" + newStudent.Group + "', studentCode = '" +
                newStudent.StudentCode + "', id_room = " + newStudent.Id_room.ToString() + ", date = '" +
                newStudent.DataIn.ToString() + "', id_user = " + newStudent.Id_user.ToString() + " where id_student = " + id_student.ToString() + ";";
        }
        public string getStrTransferStudent(int id_student, int id_room)
        {
            return "update Students set id_room = " + id_room.ToString() + " where id_student = " + id_student + ";";
        }
        public string getStrReturnRoom(int id_student)
        {
            return "update Students set id_room = -1 where id_student = " + id_student + ";";
        }
    }
}
