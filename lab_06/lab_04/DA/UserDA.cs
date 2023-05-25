using Npgsql;
using System.Data;
using InterfaceDB;
using Error;
using Models;

namespace DA
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
        public List<User> getAllUsers() 
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<User> allUser = new List<User>();
            string sql = this.getStrGetAllUser();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allUser.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Levels)reader.GetInt32(3)));
            reader.Close();
            return allUser;
        }
        public void addUser(string login, string password, Levels userLevel)
        {
            ConnectionCheck.checkConnection(this.Connector);
            int id = this.getAllUsers().Count + 1;
            string sql = getStrAddUser(id, login, password, userLevel);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public string getStrGetIdUser(string login)
        {
            return "select id from Users where login = '" + login + "';";
        }
        public string getStrGetAllUser()
        {
            return "select * from Users;";
        }
        public string getStrGetUser(int id)
        {
            return "select * from Users where id = " + id.ToString() + ";";
        }
        public string getStrAddUser(int id, string login, string password, Levels userLevel)
        {
            return "insert into Users(id, login, password, level) values (" + id.ToString() + ", '" + login + "', '" + password + "', " + ((int)userLevel).ToString() + ");";
        }
    }
}
