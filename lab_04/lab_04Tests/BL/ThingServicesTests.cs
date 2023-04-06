using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_04.Tests
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
        public Thing getThing(int id_thing)
        {
            foreach (Thing thing in this.things)
                if (thing.Id_thing == id_thing)
                    return thing;
            return new Thing(-1, -1, string.Empty, -1, null);
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
        public int getIdThingFromCode(int code)
        {
            foreach(Thing thing in this.things)
            {
                if(thing.Code == code ) 
                    return thing.Id_thing;
            }
            return -1;
        }
    }
    [TestClass()]
    public class ThingServicesTests
    {
        [TestMethod()]
        public void getThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            Thing thing = thingServices.getThing(1);

            Assert.AreEqual(thing.Id_thing, 1);
            Assert.AreEqual(thing.Code, 228);
            Assert.AreEqual(thing.Type, "Chair");
            Assert.AreEqual(thing.Id_student, 1);
            Assert.AreEqual(thing.Id_student, 1);
        }
        [TestMethod()]
        public void getThingFailTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            Assert.ThrowsException<ThingNotFoundException>(() => thingServices.getThing(4));
        }
        [TestMethod()]
        public void addThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            thingServices.addThing(2134, "Table", 1, 1);
            Thing thing = testThing.getThing(4);

            Assert.AreEqual(thing.Id_thing, 4);
            Assert.AreEqual(thing.Code, 2134);
            Assert.AreEqual(thing.Type, "Table");
        }
        [TestMethod()]
        public void addThingFailTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            Assert.ThrowsException<RoomNotFoundException>(() => thingServices.addThing(1234, "Table", 4, 1));

        }
        [TestMethod()]
        public void deleteThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            thingServices.deleteThing(1);
            Thing thing = testThing.getThing(1);

            Assert.AreEqual(thing.Id_thing, -1);
        }
        [TestMethod()]
        public void deleteThingFailTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            Assert.ThrowsException<ThingNotFoundException>(() => thingServices.deleteThing(4));

        }
        [TestMethod()]
        public void getAllThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            List<Thing> allThing = thingServices.getAllThing();

            Assert.AreEqual(allThing.Count, 3);
        }
        [TestMethod()]
        public void changeRoomThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            thingServices.changeRoomThing(1, 1, 2);
            Thing thing = testThing.getThing(2);

            Assert.AreEqual(thing.Id_room, 2);
        }
        [TestMethod()]
        public void changeRoomThingFailTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            Assert.ThrowsException<ThingNotInRoomException>(() => thingServices.changeRoomThing(1, 4, 2));

        }
        [TestMethod()]
        public void getFreeThingTest()
        {
            List<Thing> things = new List<Thing>
            {
                new Thing(1, 228, "Chair", 1, 1),
                new Thing(2, 1234, "Table", 2, 2),
                new Thing(3, 321, "Chair", 3, null)
            };
            TestThingServices testThing = new TestThingServices(things);
            TestRoomServices testRoom = new TestRoomServices(Obj.rooms);
            TestStudentServices testStudent = new TestStudentServices(Obj.students);
            ThingServices thingServices = new ThingServices(testThing, testRoom, testStudent);

            List<Thing> freeThing = thingServices.getFreeThing();

            Assert.AreEqual(freeThing[0].Id_student, null);
            Assert.AreEqual(freeThing[0].Code, 321);
            Assert.AreEqual(freeThing[0].Type, "Chair");
        }
    }
}