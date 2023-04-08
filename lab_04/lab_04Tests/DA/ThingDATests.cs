using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace lab_04.Tests
{
    [TestClass()]
    public class ThingDATests
    {
        [TestMethod()]
        public void getThingDATest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            Thing? thing = thingServices.getThing(1);
            Assert.AreEqual(thing.Id_thing, 1);
            Assert.AreEqual(thing.Type, "Table");
        }
        [TestMethod()]
        public void getThingFailTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            Assert.ThrowsException<ThingNotFoundException>(() => thingServices.getThing(99));
        }
        [TestMethod()]
        public void addThingTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            thingServices.addThing(1235321, "Bed", 1, 1);

            NpgsqlCommand command = new NpgsqlCommand(thingDA.getStrGetThing(2), thingDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Thing thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetInt32(4));
            reader.Close();

            Assert.AreEqual(thing.Id_thing, 2);
            Assert.AreEqual(thing.Code, 1235321);
            Assert.AreEqual(thing.Type, "Bed");
        }
        [TestMethod]
        public void deleteThingTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            thingServices.deleteThing(2);
            NpgsqlCommand command = new NpgsqlCommand(thingDA.getStrGetThing(2), thingDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
        [TestMethod]
        public void changeRoomThingTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            thingServices.changeRoomThing(1, 1, 2);
            NpgsqlCommand command = new NpgsqlCommand(thingDA.getStrGetThing(1), thingDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Thing thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetInt32(4));
            reader.Close();

            Assert.AreEqual(thing.Id_room, 2);
        }
    }
}