using Models;
using Error;
using InterfaceDB;

namespace BL
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
        public void addThing(int code, string name)
        {
            List<Thing> allThing = this.ithingDB.getAllThing();
            foreach (Thing thing in allThing) 
                if(thing.Code == code)
                    throw new CodeThingExistsException();
            this.ithingDB.addThing(new Thing(code, name));
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
        public void transferStudentThing(int id_student, int id_thing)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            Thing? thing = this.ithingDB.getThing(id_thing);
            if (thing == null)
                throw new ThingNotFoundException();
            if (thing.Id_student == null || thing.Id_room == 1)
                this.ithingDB.transferStudentThing(id_student, id_thing, student.Id_room);
            else throw new ThingNotFreeException();
        }
        public void returnThing(int id_student, int id_thing)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            Thing? thing = this.ithingDB.getThing(id_thing);
            if (thing == null)
                throw new ThingNotFoundException();
            if (thing.Id_student == id_student)
                this.ithingDB.returnThing(id_thing);
            else throw new WrongOwnerThingException();
        }
        public List<Thing> getStudentThing(int id_student)
        {
            Student? student = this.istudentDB.getStudent(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            List<Thing> allThing = this.ithingDB.getAllThing();
            List<Thing> result = new List<Thing>();
            foreach (Thing thing in allThing)
                if(thing.Id_student == id_student)
                    result.Add(thing);
            return result;
        }
        public List<Thing> getFreeThing() => ithingDB.getAllThing().Where(x => (x.Id_student == -1 || x.Id_student == null)).ToList();
    }
}
