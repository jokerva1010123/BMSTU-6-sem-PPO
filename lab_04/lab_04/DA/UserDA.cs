using Npgsql;
using System.Data;

namespace lab_04
{
    public class UserDA : IUserDB
    {
        private string connectString;
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public UserDA(ConnectionArgs args)
        {
            this.connectString = args.getString();
            this.Connector = new NpgsqlConnection(this.connectString);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public int getIdUser(string login)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetIdUser(login);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
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
        public User? getUser(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetUser(id);
            User? user = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
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
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrAddUser(login, password, userLevel);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public string getStrGetIdUser(string login)
        {
            return "select id from Users where login = '" + login + "';";
        }
        public string getStrGetUser(int id)
        {
            return "select * from Users where id = " + id.ToString() + ";";
        }
        public string getStrAddUser(string login, string password, Levels userLevel)
        {
            return "insert into Users(login, password, level) values ('" + login + "', '" + password + "', " + ((int)userLevel).ToString() + ");";
        }
    }
}
