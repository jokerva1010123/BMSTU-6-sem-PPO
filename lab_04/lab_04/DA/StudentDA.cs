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
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public int getIdStudentFromCode(string code)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            int id_student = -1;
            string sql = SqlStr.getStrGetIdStudent(code);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if(reader.FieldCount != 1)
                throw new DataBaseConnectException();
            reader.Read();
            id_student = reader.GetInt32(0);            
            return id_student;
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
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.FieldCount != 1)
                throw new DataBaseConnectException();
            reader.Read();
            return new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)));
        }
        public List<Student> getAllStudent()
        {
            List<Student> allStudent = new List<Student>();
            string sql = SqlStr.getStrGetAllStudent();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Student student = new Student(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), 
                  reader.GetInt32(4), DateTime.Parse(reader.GetString(5)));
            }
            return allStudent;
        }
    }
}
