using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class ThingServices
    {
        private IThingDB ithingDB;
        private readonly IRoomDB iroomDB;
        private readonly IStudentDB istudentDB;
        public IThingDB IthingDB { get => ithingDB; set => ithingDB = value; }
        public ThingServices(IThingDB thingDB, IRoomDB iroomDB, IStudentDB istudentDB)
        {
            this.ithingDB = thingDB;
            this.istudentDB = istudentDB;
            this.iroomDB = iroomDB;
        }
        public void addThing(int code, string name, int id_room, int id_student)
        {
            if (istudentDB.getStudent(id_student) == null)
                throw new StudentNotFoundException();
            else
            {
                if (iroomDB.getRoom(id_room) == null)
                    throw new RoomNotFoundException();
                else
                {
                    List<Thing> allThing = this.ithingDB.getAllThing();
                    foreach (Thing thing in allThing)
                        if (thing.Code == code)
                            throw new CodeThingExistsException();
                    this.ithingDB.addThing(new Thing(code, name, id_room, id_student));
                }
            }
        }
        public void deleteThing(int id_thing)
        {
            Thing? thing = this.getThing(id_thing);
            if (thing != null)
                this.ithingDB.deleteThing(id_thing);
            else
                throw new ThingNotFoundException();
        }
        public Thing getThing(int id_thing)
        {
            Thing? thing = this.ithingDB.getThing(id_thing);
            if (thing != null)
                return thing;
            else
                throw new ThingNotFoundException();
        }
        public List<Thing> getAllThing()
        {
            return this.ithingDB.getAllThing();
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            Thing? thing = this.ithingDB.getThing(id_thing);
            if (thing == null)
                throw new ThingNotFoundException();
            else
                if (thing.Id_room != id_from)
                    throw new ThingNotInRoomException();
                else
                {
                    Room? room = this.iroomDB.getRoom(id_to);
                    if (room == null)
                        throw new RoomNotFoundException();
                    else
                        this.IthingDB.changeRoomThing(id_thing, id_from, id_to);
                }
        }
        public int getIdThingFromCode(int code)
        {
            int id_thing = this.ithingDB.getIdThingFromCode(code);
            if (id_thing == -1)
                throw new ThingNotFoundException();
            else
                return id_thing;
        }
        public List<Thing> getFreeThing() => ithingDB.getAllThing().Where(x => !x.Id_student.HasValue).ToList();
    }
}
