using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Error;
using Models;
using BL;

namespace Tests.BL
{
    public class TestRoomServices : IRoomDB
    {
        public List<Room> rooms;
        public TestRoomServices(List<Room> rooms)
        {
            this.rooms = rooms;
        }
        public void addRoom(Room room)
        {
            int N = this.rooms.Count;
            this.rooms.Add(new Room(N + 1, room.Number, room.RoomTypes));
        }
        public void deleteRoom(int id_room)
        {
            List<Room> newRoom = new List<Room>();
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room != id_room)
                    newRoom.Add(tmpRoom);
            this.rooms = newRoom;
        }
        public Room? getRoom(int id_room)
        {
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room == id_room)
                    return tmpRoom;
            return null;
        }
        public List<Room> getAllRoom()
        {
            return this.rooms;
        }
    }
    [TestClass()]
    public class RoomServicesTests
    {
        [TestMethod()]
        public void getRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            Room room = roomServices.getRoom(1);
            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 528);
            Assert.AreEqual(room.RoomTypes, RoomType.StudentRoom);
        }
        [TestMethod()]
        public void getRoomFailTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            Assert.ThrowsException<RoomNotFoundException>(() => roomServices.getRoom(4));
        }
        [TestMethod()]
        public void addRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            roomServices.addRoom(new Room(312, RoomType.StudentRoom));
            Room room = testRoom.getRoom(4);
            Assert.AreEqual(room.Id_room, 4);
            Assert.AreEqual(room.Number, 312);
            Assert.AreEqual(room.RoomTypes, RoomType.StudentRoom);
        }
        [TestMethod()]
        public void addRoomFailTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            Assert.ThrowsException<RoomExistsException>(() => roomServices.addRoom(new Room(428, RoomType.StudentRoom)));
        }
        [TestMethod()]
        public void deleteRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            roomServices.deleteRoom(2);
            Room room = testRoom.getRoom(2);

            Assert.AreEqual(room, null);
        }
        [TestMethod()]
        public void deleteRoomFailTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            Assert.ThrowsException<RoomNotFoundException> (() => roomServices.deleteRoom(4));
        }
        [TestMethod()]
        public void getAllRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            List <Room> allRooms = roomServices.getAllRoom();
            Assert.AreEqual(allRooms.Count, 3);
        }
    }
}