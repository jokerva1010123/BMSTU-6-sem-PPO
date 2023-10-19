using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Models;
using BL;
using DA;

namespace Tests.BL
{
    public class TestThingServices : IThingDB
    {
        private List<Thing> things;
        public TestThingServices(List<Thing> things)
        {
            this.things = things;
        }
        public void addThing(Thing thing)
        {
            int N = this.things.Count;
            this.things.Add(new Thing(N + 1, thing.Code, thing.Type, thing.Id_room, thing.Id_student));
            this.things.Add(new Thing(N + 1, thing.Code, thing.Type, thing.Id_room, thing.Id_student));
        }
        public List<Thing> getAllThing()
        {
            return this.things;
        }
        public void deleteThing(int id_thing)
        {
            List<Thing> newThings = new List<Thing>();
            foreach (Thing thing in this.things)
                if (thing.Id_thing != id_thing)
                    newThings.Add(thing);
            this.things = newThings;
        }
        public Thing? getThing(int id_thing)
        {
            foreach (Thing thing in this.things)
                if (thing.Id_thing == id_thing)
                    return thing;
            return null;
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            List<Thing> newThings = new List<Thing>();
            foreach (Thing thing in this.things)
            {
                if ((thing.Id_thing == id_thing) && (thing.Id_room == id_from))
                    thing.Id_room = id_to;
                newThings.Add(thing);
            }
            this.things = newThings;
        }
        public void transferStudentThing(int id_student, int id_thing, int id_room)
        {
            foreach (Thing thing in this.things)
            {
                if (thing.Id_thing == id_thing)
                {
                    thing.Id_student = id_student;
                    thing.Id_room = id_room;
                }
            }
        }
        public int getIdThingFromCode(int code)
        {
            foreach (Thing thing in this.things)
                if (thing.Code == code)
                    return thing.Id_thing;
            return -1;
        }
        public void returnThing(int id_thing)
        {
            foreach (Thing thing in this.things)
            {
                if (thing.Id_thing == id_thing)
                {
                    thing.Id_student = -1;
                    thing.Id_room = 1;
                }
            }
        }
    }
    [TestClass()]
    public class ThingServicesTests
    {
        [TestMethod()]
        public void tranferthingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 2, 2),
                new Thing(2, 1234, "Table",2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
            };

            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            thingServices.transferStudentThing(1, 3);

            Assert.AreEqual(things[2].Id_student, 1);
        }
        [TestMethod()]
        public void returnThing()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 3, 2),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
            };

            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            thingServices.returnThing(2, 1);

            Assert.AreEqual(things[0].Id_student, -1);
            Assert.AreEqual(things[0].Id_room, 1);
        }[TestMethod()]
        public void getIdThingFromCode()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
            };

            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            int id_thing = thingServices.getIdThingFromCode(228);

            Assert.AreEqual(id_thing, 1);
        }
    }
}
