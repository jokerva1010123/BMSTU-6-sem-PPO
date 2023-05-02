using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Error;
using Models;
using DA;
using BL;

namespace Tests.DA
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
            Assert.AreEqual(room.Number, 101);
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
            List<Room> allRoom = roomServices.getAllRoom();
            Room room = allRoom[allRoom.Count - 1];
            NpgsqlCommand command = new NpgsqlCommand(roomDA.getStrGetRoom((int)room.Id_room), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Room tmproom = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2));
            reader.Close();

            Assert.AreEqual(tmproom.Number, 413);
            Assert.AreEqual(tmproom.RoomTypes, RoomType.StudentRoom);
            roomServices.deleteRoom((int)room.Id_room);
        }
        [TestMethod()]
        public void deleteRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);
            roomServices.addRoom(new Room(413, RoomType.StudentRoom));
            List<Room> allRoom = roomServices.getAllRoom();
            Room room = allRoom[allRoom.Count - 1];
            roomServices.deleteRoom((int)room.Id_room);
            NpgsqlCommand command = new NpgsqlCommand(roomDA.getStrGetRoom((int)room.Id_room), roomDA.Connector);
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
            Assert.AreEqual(allRoom.Count, 11);
        }
    }
}