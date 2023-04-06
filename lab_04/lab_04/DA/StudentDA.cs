using Npgsql;
using System.Data;

namespace lab_04
{
    public class StudentDA : IStudentDB
    {
        private string connectString;
        private NpgsqlConnection connector;
        public StudentDA(ConnectionArgs args)
        {
            this.connectString = args.getString();
            this.connector = new NpgsqlConnection(this.connectString);
            if (this.connector == null)
                throw new DataBaseConnectException();
            this.connector.Open();
            if (this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addStudent(Student student)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrAddStudent(student);
            Console.WriteLine(sql);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public int getIdStudentFromCode(string code)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetIdStudent(code);
            int id = -1;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
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
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrChangeStudent(id_student, newStudent);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public Student getStudent(int id_student)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetStudent(id_student);
            Student student = new Student(-1, string.Empty, string.Empty, string.Empty, -1, DateTime.Parse("Jan 01 1000"));
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
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
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            List<Student> allStudent = new List<Student>();
            string sql = SqlStr.getStrGetAllStudent();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
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
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrTransferStudent(id_student, id_room);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
    }
}
