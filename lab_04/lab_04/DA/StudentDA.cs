using Npgsql;
using System.Data;

namespace lab_04
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
            student.Id_student = this.getAllStudent().Count + 1;
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
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)));
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
                      reader.GetInt32(4), DateTime.Parse(reader.GetString(5)));
                    allStudent.Add(student);
                }
            }
            reader.Close();
            return allStudent;
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
            return "insert into Students(id_student, name, groupStudent, studentCode, id_room, date) values (" + student.Id_student.ToString() + ", '"
                + student.Name + "', '" + student.Group + "', '" + student.StudentCode + "', " +
                student.Id_room.ToString() + ", '" + student.DataIn.ToString() + "');";
        }
        public string getStrGetAllStudent()
        {
            return "select * from Students";
        }
        string getStrGetIdStudent(string code)
        {
            return "select id_student from Students where studentCode = '" + code + "';";
        }
        public string getStrGetStudent(int id_student)
        {
            return "select * from Students where id_student = " + id_student.ToString() + ";";
        }
        string getStrChangeStudent(int id_student, Student newStudent)
        {
            return "update Students set name = '" + newStudent.Name + "', groupStudent = '" + newStudent.Group + "', studentCode = '" +
                newStudent.StudentCode + "', id_room = " + newStudent.Id_room.ToString() + ", date = " +
                newStudent.DataIn.ToString() + " where id_student = " + id_student.ToString() + ";";
        }
        string getStrTransferStudent(int id_student, int id_room)
        {
            return "update Students set id_room = " + id_room.ToString() + " where id_stdudent = " + id_student + ";";
        }
    }
}
