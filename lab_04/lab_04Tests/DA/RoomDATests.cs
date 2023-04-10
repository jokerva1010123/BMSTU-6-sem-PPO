using lab_04Tests.DA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace lab_04.Tests
{
    [TestClass()]
    public class RoomDATests
    {
        [TestMethod()]
        public void getRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            Room? room = roomServices.getRoom(1);
            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 312);
        }
        [TestMethod()]
        public void getRoomFailTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            Assert.ThrowsException<RoomNotFoundException>(() => roomServices.getRoom(999));
        }
        [TestMethod()]
        public void addRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            roomServices.addRoom(new Room(413, RoomType.StudentRoom));

            NpgsqlCommand command = new NpgsqlCommand(roomDA.getStrGetRoom(3), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2));
            reader.Close();

            Assert.AreEqual(room.Number, 413);
            Assert.AreEqual(room.RoomTypes, RoomType.StudentRoom);
        }
        [TestMethod()]
        public void deleteRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            roomServices.deleteRoom(3);
            NpgsqlCommand command = new NpgsqlCommand(roomDA.getStrGetRoom(3), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
        [TestMethod()]
        public void getAllRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            List<Room> allRoom = roomServices.getAllRoom();
            Assert.AreEqual(allRoom.Count, 2);
        }
    }
}