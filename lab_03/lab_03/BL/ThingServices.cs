using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class ThingServices
    {
        private IThingDB ithingDB;

        public IThingDB IthingDB { get => ithingDB; set => ithingDB = value; }

        public ThingServices(IThingDB thingDB)
        {
            this.ithingDB = thingDB;
        }

        public void addThing(int code, string name, int id_room, int id_student)
        {
            this.ithingDB.addThing(new Thing(code, name, id_room, id_student));
        }
        public void deleteThing(int id_thing)
        {
            Thing thing = this.ithingDB.getThing(id_thing);
            if (thing != null)
                this.ithingDB.deleteThing(id_thing);
        }
        public Thing getThing(int id_thing)
        {
            return this.ithingDB.getThing(id_thing);
        }
        public List<Thing> getAllThing()
        {
            return this.ithingDB.getAllThing();
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            this.ithingDB.changeRoomThing(id_thing, id_from, id_to);
        }
        public List<Thing> getFreeThing()
        {
            List <Thing> allThings = ithingDB.getAllThing();
            List <Thing> result = new List<Thing>();
            foreach (Thing thing in allThings) 
                if (thing.Id_student == -1)
                    result.Add(thing);
            return result;
        }
    }
}
