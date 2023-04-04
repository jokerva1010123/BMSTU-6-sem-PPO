using Npgsql;
namespace lab_04
{
    public class ConnectionArgs
    {
        private string user;
        private string password;
        private string host;
        private string database;
        private int port;

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Host { get => host; set => host = value; }
        public string Database { get => database; set => database = value; }
        public int Port { get => port; set => port = value; }

        public ConnectionArgs(){ }
        public ConnectionArgs(string user, string host, string database, string password, int port) 
        { 
            this.user = user;
            this.password = password;
            this.host = host;
            this.database = database;
            this.port = port;
        }
        public ConnectionArgs(ConnectionArgs args) 
        {
            this.user = args.User;
            this.password = args.Password;
            this.host = args.Host;
            this.database = args.Database;
            this.port = args.Port;
        }
        public string getString()
        {
            return "Host = "+ this.host +"; Username = " + this.user + "; Password = " + this.password + "; Database = " + this.database + ";";
        }

    }
    public class Connection
    {
        private ConnectionArgs args;
        private NpgsqlConnection connnector;


        public ConnectionArgs Args { get => args; set => args = value; }
        public NpgsqlConnection Connnector { get => connnector; set => connnector = value; }

        public Connection(ConnectionArgs args)
        {
            this.args = args;
            this.connnector = new NpgsqlConnection();
        }

    }
}
