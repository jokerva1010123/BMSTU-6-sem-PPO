using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_04.Tests
{
    [TestClass()]
    public class RoomDATests
    {
        [TestMethod()]
        public void getRoomTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            Room room = roomServices.getRoom(1);
            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 312);
        }
        [TestMethod()]
        public void getRoomFailTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            Assert.ThrowsException<RoomNotFoundException>(() => roomServices.getRoom(999));
        }
        [TestMethod()]
        public void addRoomTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            roomServices.addRoom(new Room(413, RoomType.StudentRoom));
            Room room = roomDA.getRoom(2);
            Assert.AreEqual(room.Number, 413);
            Assert.AreEqual(room.RoomTypes, RoomType.StudentRoom);

        }
        [TestMethod()]
        public void deleteRoomTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            roomServices.deleteRoom(2);
            Room room = roomDA.getRoom(2);
            Assert.AreEqual(room.Id_room, null);
        }
        [TestMethod()]
        public void getAllRoomTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            List<Room> allRoom = roomServices.getAllRoom();
            Assert.AreEqual(allRoom.Count, 1);
        }
    }
}