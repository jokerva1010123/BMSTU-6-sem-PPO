using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Error;
using Models;
using DA;
using BL;

namespace Tests.DA
{
    [TestClass()]
    public class ThingDATests
    {
        [TestMethod()]
        public void getThingDATest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
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
            ConnectionArgs args = GetConnectArgs.getarg();
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            Assert.ThrowsException<ThingNotFoundException>(() => thingServices.getThing(99));
        }
        [TestMethod()]
        public void addThingTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            thingServices.addThing(12311321, "Bed");

            int id_thing = thingServices.getIdThingFromCode(12311321);
            NpgsqlCommand command = new NpgsqlCommand(thingDA.getStrGetThing(id_thing), thingDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Thing thing = new Thing(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetInt32(4));
            reader.Close();

            Assert.AreEqual(thing.Id_thing, id_thing);
            Assert.AreEqual(thing.Code, 12311321);
            Assert.AreEqual(thing.Type, "Bed");
            thingServices.deleteThing(id_thing);
        }
        [TestMethod]
        public void deleteThingTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            ThingDA thingDA = new ThingDA(args);
            StudentDA studentDA = new StudentDA(args);
            RoomDA roomDA = new RoomDA(args);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);
            thingServices.addThing(12311321, "Bed");
            thingServices.deleteThing(thingServices.getIdThingFromCode(12311321));
            NpgsqlCommand command = new NpgsqlCommand(thingDA.getStrGetThing(2), thingDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();          
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
        [TestMethod]
        public void changeRoomThingTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
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
            thingServices.changeRoomThing(1, 2, 1);

        }
    }
}