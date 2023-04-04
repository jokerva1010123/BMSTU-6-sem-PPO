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
            if (this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
        }
        public void addRoom(Room room)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrAddRoom(room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            command.ExecuteNonQuery();
        }
        public Room getRoom(int id_room)
        {
            Room room;
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrGetRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if(reader.FieldCount != 1)
                throw new DataBaseConnectException();
            reader.Read();
            room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2));
            return room;
        }
        public void deleteRoom(int id_room)
        {
            if (this.connector == null || this.connector.State == ConnectionState.Closed)
                throw new DataBaseConnectException();
            string sql = SqlStr.getStrDeleteRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            command.ExecuteNonQuery();
        }
        public List<Room> getAllRoom()
        {
            List<Room> allRoom = new List<Room>();
            string sql = SqlStr.getStrGetAllRoom();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                reader.Read();
                allRoom.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2)));
            }
            return allRoom;
        }
    }
}
    