using Npgsql;
using System.Data;
namespace lab_04
{
    public class ThingDA : IThingDB
    {
        private string connectString;
        private NpgsqlConnection connector;
        public ThingDA(ConnectionArgs Args)
        {
            this.connectString = Args.getString();
            this.connector = new NpgsqlConnection(this.connectString);
            if (this.connector == null)
                throw new DataBaseConnectException();
            this.connector.Open();
            if (this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
        }
        public void addThing(Thing thing)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrAddThing(thing);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public void deleteThing(int id_thing)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrDeleteThing(thing);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public Thing getThing(int id_thing)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetThing(id_thing);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetInt32(4));
        }
        public List<Thing> getAllThing()
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetAllThing();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Thing> allThing = new List<Thing>();
            while(reader.Read()) 
            {
                Thing thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                    reader.GetInt32(4));
                allThing.Add(thing);
            }       
            return allThing;
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrChangeRoomThing(id_thing, id_from, id_to);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            cmd.ExecuteNonQuery();
        }
        public int getIdThingFromCode(int code)
        {            
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetIdThing(code);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }
    }
}
