using Npgsql;
using System.Data;
using System.Data.SqlTypes;

namespace lab_04
{
    public class RoomDA : IRoomDB
    {
        private string connectString;
        private NpgsqlConnection connector;
        public RoomDA(ConnectionArgs Args)
        {
            this.connectString = Args.getString();
            this.connector = new NpgsqlConnection(this.connectString);
            if (this.connector == null)
                throw new DataBaseConnectException();
            this.connector.Open();
            if (this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addRoom(Room room)
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrAddRoom(room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            command.ExecuteNonQuery();
        }
        public Room getRoom(int id_room)
        {
            Room room = new Room(null, -1, RoomType.None);
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
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
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrDeleteRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            command.ExecuteNonQuery();
        }
        public List<Room> getAllRoom()
        {
            if (this.connector == null || this.connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
            List<Room> allRoom = new List<Room>();
            string sql = SqlStr.getStrGetAllRoom();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read()) 
                    allRoom.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2)));
            reader.Close();
            return allRoom;
        }
    }
}
    