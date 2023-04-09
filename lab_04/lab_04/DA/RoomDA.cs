using Npgsql;
using System.Data;

namespace lab_04
{
    public class RoomDA : IRoomDB
    {
        private string connectString;
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public RoomDA(ConnectionArgs Args)
        {
            this.connectString = Args.getString();
            this.Connector = new NpgsqlConnection(this.connectString);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addRoom(Room room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrAddRoom(room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public Room? getRoom(int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            Room? room = null;
            string sql = getStrGetRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2));
            }
            reader.Close();
            return room;
        }
        public void deleteRoom(int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrDeleteRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public List<Room> getAllRoom()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Room> allRoom = new List<Room>();
            string sql = getStrGetAllRoom();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read()) 
                    allRoom.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2)));
            reader.Close();
            return allRoom;
        }
        string getStrAddRoom(Room room)
        {
            return "insert into Rooms(number, roomtype) values ('" +
                room.Number.ToString() + "', " + ((int)room.RoomTypes).ToString() + ");";
        }
        public string getStrGetRoom(int id_room)
        {
            return "select * from Rooms where id_room = " + id_room.ToString() + ";";
        }
        string getStrGetAllRoom()
        {
            return "select * from Rooms;";
        }
        string getStrDeleteRoom(int id_room)
        {
            return "delete from Rooms where id_room = " + id_room.ToString() + ";";
        }
    }
}
    