using InterfaceDB;
using Models;
using MongoDB.Driver;

namespace MongoDB
{
	public class ThingMongo : IThingDB
	{
		private string connectionString = "";
		private const string database = "PPO";
		private const string ThingCollection = "Things";
		private readonly IMongoCollection<Thing> thingCollection;
		public ThingMongo(string connectionString)
		{
			this.connectionString = connectionString;
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(database);
			thingCollection = db.GetCollection<Thing>(ThingCollection);
		}
		public void addThing(Thing thing)
		{
			thing.Id_thing = getAllThing().Count + 1;
			thingCollection.InsertOne(thing);
		}
		public void deleteThing(int id_thing)
		{
			var filter = Builders<Thing>.Filter.Eq(t => t.Id_thing, id_thing);
			thingCollection.DeleteOne(filter);
		}
		public Thing? getThing(int id_thing)
		{
			var projection = Builders<Thing>.Projection.Exclude("_id");
			var thing = thingCollection.Find(t => t.Id_thing == id_thing).Project(projection).ToList();
			if (thing == null) return null;
			return new Thing(thing[0]["Id_thing"].ToInt32(), thing[0]["Code"].ToInt32(), thing[0]["Type"].ToString(), thing[0]["Id_room"].ToInt32(), thing[0]["Id_student"].ToInt32());
		}
		public List<Thing> getAllThing()
		{
			var projection = Builders<Thing>.Projection.Exclude("_id");
			var all = thingCollection.Find(_ => true).Project(projection).ToList();
			List<Thing> things = new List<Thing>();
			foreach (var thing in all)
				things.Add(new Thing(thing["Id_thing"].ToInt32(), thing["Code"].ToInt32(), thing["Type"].ToString(), thing["Id_room"].ToInt32(), thing["Id_student"].ToInt32()));
			return things;
		}
		public void changeRoomThing(int id_thing, int id_from, int id_to)
		{
			var filter = Builders<Thing>.Filter.Eq(t => t.Id_thing, id_thing);
			var update = Builders<Thing>.Update.Set(t => t.Id_room, id_to);
			thingCollection.UpdateOne(filter, update);
		}
		public int getIdThingFromCode(int code)
		{
			var projection = Builders<Thing>.Projection.Exclude("_id");
			var thing = thingCollection.Find(t => t.Code == code).Project(projection).ToList();
			if (thing == null) return -1;
			return thing[0]["Id_thing"].ToInt32();
		}
		public void transferStudentThing(int id_student, int id_thing, int id_room)
		{
			var filter = Builders<Thing>.Filter.Eq(t => t.Id_thing, id_thing);
			var update = Builders<Thing>.Update.Set(t => t.Id_room, id_room).Set(t=>t.Id_student, id_student);
			thingCollection.UpdateOne(filter, update);
		}
		public void returnThing(int id_thing)
		{
			var filter = Builders<Thing>.Filter.Eq(t => t.Id_thing, id_thing);
			var update = Builders<Thing>.Update.Set(t => t.Id_room, 1).Set(t => t.Id_student, -1);
			thingCollection.UpdateOne(filter, update);
		}
	}
}
