using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace lab_03.Tests
{
    [TestClass()]
    public class ThingServicesTests
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
                return new Thing();
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
        }
        [TestMethod()]
        public void addThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);

            thingServices.addThing(2134, "Table", 1, 1);
            Thing thing = thingServices.getThing(4);

            Assert.AreEqual(thing.Id_thing, 4);
            Assert.AreEqual(thing.Code, 2134);
            Assert.AreEqual(thing.Type, "Table");   
        }
        [TestMethod()]
        public void deleteThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);

            thingServices.deleteThing(1);
            Thing thing = thingServices.getThing(1);

            Assert.AreEqual(thing.Id_thing, -1);        
        }
        [TestMethod()]
        public void getThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);

            Thing thing = thingServices.getThing(1);

            Assert.AreEqual(thing.Id_thing, 1);
            Assert.AreEqual(thing.Code, 228);
            Assert.AreEqual(thing.Type, "Chair");
            Assert.AreEqual(thing.Id_student, 1);
            Assert.AreEqual(thing.Id_student, 1);
        }
        [TestMethod()]
        public void getAllThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);

            List<Thing> allThing = thingServices.getAllThing();

            Assert.AreEqual(allThing.Count, 3);
        }
        [TestMethod()]
        public void changeRoomThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);
            
            thingServices.changeRoomThing(1, 1, 2);
            Thing thing = thingServices.getThing(2);

            Assert.AreEqual(thing.Id_room, 2);
        }
        [TestMethod()]
        public void getFreeThingTest()
        {
            List<Thing> things = new List<Thing>();
            things.Add(new Thing(1, 228, "Chair", 1, 1));
            things.Add(new Thing(2, 1234, "Table", 2, 2));
            things.Add(new Thing(3, 321, "Chair", 3, -1));

            TestThingServices testThing = new TestThingServices(things);
            ThingServices thingServices = new ThingServices(testThing);

            List<Thing> freeThing = thingServices.getFreeThing();

            Assert.AreEqual(freeThing[0].Id_student, -1);
            Assert.AreEqual(freeThing[0].Code, 321);
            Assert.AreEqual(freeThing[0].Type, "Chair");
        }
    }
}