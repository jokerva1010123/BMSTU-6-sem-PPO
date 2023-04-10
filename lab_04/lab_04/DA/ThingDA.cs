using Npgsql;
using System.Data;
namespace lab_04
{
    public class ThingDA : IThingDB
    {
        private string connectString;
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public ThingDA(ConnectionArgs Args)
        {
            this.connectString = Args.getString();
            this.Connector = new NpgsqlConnection(this.connectString);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addThing(Thing thing)
        {
            ConnectionCheck.checkConnection(this.Connector);
            thing.Id_thing = this.getAllThing().Count + 1;
            string sql = getStrAddThing(thing);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void deleteThing(int id_thing)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrDeleteThing(id_thing);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public Thing? getThing(int id_thing)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetThing(id_thing);
            Thing? thing = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetInt32(4));
            }
            reader.Close();
            return thing;
        }
        public List<Thing> getAllThing()
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetAllThing();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Thing> allThing = new List<Thing>();
            if(reader.HasRows) 
                while(reader.Read()) 
                {
                    Thing thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                        reader.GetInt32(4));
                    allThing.Add(thing);
                }       
            reader.Close();
            return allThing;
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrChangeRoomThing(id_thing, id_to);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public int getIdThingFromCode(int code)
        {            
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrGetIdThing(code);
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
        string getStrAddThing(Thing thing)
        {
            return "insert into Things(id_thing, code, type, id_room, id_student) values (" + thing.Id_thing.ToString() + ", "
                + thing.Code.ToString() + ", '" + thing.Type.ToString() + "', " + thing.Id_room.ToString() + ", " +
                thing.Id_student.ToString() + ");";
        }
        public string getStrGetThing(int id_thing)
        {
            return "select * from Things where id_thing = " + id_thing.ToString() + ";";
        }
        string getStrGetAllThing()
        {
            return "select * from Things";
        }
        string getStrDeleteThing(int id_thing)
        {
            return "delete from Things where id_thing = " + id_thing.ToString() + ";";
        }
        string getStrGetIdThing(int code)
        {
            return "select id_thing from Things where code = " + code.ToString() + ";";
        }
        string getStrChangeRoomThing(int id_thing, int id_to)
        {
            return "update Things set id_room = " + id_to.ToString() + " where id_thing = " + id_thing.ToString() + ";";
        }
    }
}
