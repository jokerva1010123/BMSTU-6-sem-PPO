﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03.Tests
{
    public class TestRoomServices : IRoomDB
    {
        private List<Room> rooms;
        public TestRoomServices(List<Room> rooms)
        {
            this.rooms = rooms;
        }
        public void addRoom(Room room)
        {
            int N = this.rooms.Count;
            this.rooms.Add(new Room(N + 1, room.Number, room.RoomType));
        }
        public void deleteRoom(int id_room)
        {
            List<Room> newRoom = new List<Room>();
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room != id_room)
                    newRoom.Add(tmpRoom);
            this.rooms = newRoom;
        }
        public Room getRoom(int id_room)
        {
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room == id_room)
                    return tmpRoom;
            return new Room();
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
        public void addRoomTest()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(1, 528, "StudenRoom"));
            rooms.Add(new Room(2, 428, "StudenRoom"));
            rooms.Add(new Room(3, 1, "Storage"));
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            roomServices.addRoom(new Room(312, "StudentRoom"));
            Room room = roomServices.getRoom(4);

            Assert.AreEqual(room.Id_room, 4);
            Assert.AreEqual(room.Number, 312);
            Assert.AreEqual(room.RoomType, "StudentRoom");
        }

        [TestMethod()]
        public void getRoomTest()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(1, 528, "StudenRoom"));
            rooms.Add(new Room(2, 428, "StudenRoom"));
            rooms.Add(new Room(3, 1, "Storage"));
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            Room room = roomServices.getRoom(1);

            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 528);
            Assert.AreEqual(room.RoomType, "StudenRoom");
        }

        [TestMethod()]
        public void deleteRoomTest()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(1, 528, "StudenRoom"));
            rooms.Add(new Room(2, 428, "StudenRoom"));
            rooms.Add(new Room(3, 1, "Storage"));
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            roomServices.deleteRoom(2);
            Room room = roomServices.getRoom(2);

            Assert.AreEqual(room.Id_room, -1);
        }

        [TestMethod()]
        public void getAllRoomTest()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(1, 528, "StudenRoom"));
            rooms.Add(new Room(2, 428, "StudenRoom"));
            rooms.Add(new Room(3, 1, "Storage"));
            TestRoomServices testRoom = new TestRoomServices(rooms);
            RoomServices roomServices = new RoomServices(testRoom);

            List <Room> allRooms = roomServices.getAllRoom();

            Assert.AreEqual(allRooms.Count, 3);
        }
    }
}