using Npgsql;
using System.Data;
using System.Reflection.PortableExecutable;

namespace lab_04
{
    public class UserDA : IUserDB
    {
        private string connectString;
        private NpgsqlConnection connector;
        public UserDA(ConnectionArgs args)
        {
            this.connectString = args.getString();
            this.connector = new NpgsqlConnection(this.connectString);
            if (this.connector == null)
                throw new DataBaseConnectException();
            this.connector.Open();
            if (this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public int getIdUser(string login)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetIdUser(login);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            int id = -1;
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;
        }
        public User getUser(int id)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetUser(id);
            User user = new User(-1, string.Empty, string.Empty, Levels.NONE);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Levels)reader.GetInt32(3));
            }
            reader.Close();
            return user;
        }
        public void addUser(string login, string password, Levels userLevel)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrAddUser(login, password, userLevel);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
    }
}
