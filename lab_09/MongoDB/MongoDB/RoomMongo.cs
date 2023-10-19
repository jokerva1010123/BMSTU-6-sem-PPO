using InterfaceDB;
using Models;
using MongoDB.Driver;
using System.Collections.Specialized;

namespace MongoDB
{
	public class RoomMongo : IRoomDB
	{
		private string connectionString = "";
		private const string database = "PPO";
		private const string RoomCollection = "Rooms";
		private readonly IMongoCollection<Room> roomCollection;
		public RoomMongo(string connectionString)
		{
			this.connectionString = connectionString;
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(database);
			roomCollection = db.GetCollection<Room>(RoomCollection);
		}
		public List<Room> getAllRoom()
		{
			var projection = Builders<Room>.Projection.Exclude("_id");
			var all = roomCollection.Find(_ => true).Project(projection).ToList();
			List<Room> rooms = new List<Room>();
			foreach (var room in all)
				rooms.Add(new Room(room["Id_room"].ToInt32(), room["Number"].ToInt32(), (RoomType)room["RoomTypes"].ToInt32()));
			return rooms;
		}
		public void addRoom(Room room)
		{
			room.Id_room = getAllRoom().Count + 1;
			roomCollection.InsertOne(room);
		}
		public Room getRoom(int id_room)
		{
			var projection = Builders<Room>.Projection.Exclude("_id");
			var room = roomCollection.Find(r => r.Id_room == id_room).Project(projection).ToList();
			if (room == null) return null;
			return new Room(room[0]["Id_room"].ToInt32(), room[0]["Number"].ToInt32(), (RoomType)room[0]["RoomTypes"].ToInt32());
		}
		public void deleteRoom(int id_room)
		{
			var filter = Builders<Room>.Filter.Eq(r => r.Id_room, id_room);
			roomCollection.DeleteOne(filter);
		}
	}
}
