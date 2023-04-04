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
            if (istudentDB.getStudent(id_student).Id_student == -1)
                throw new StudentNotFoundException();
            else
               if (iroomDB.getRoom(id_room).Id_room == null)
                throw new RoomNotFoundException();
            else
            {
                this.ithingDB.addThing(new Thing(code, name, id_room, id_student));
            }
        }
        public void deleteThing(int id_thing)
        {
            if (this.ithingDB.getThing(id_thing).Id_thing != -1)
                this.ithingDB.deleteThing(id_thing);
            else
            {
                throw new ThingNotFoundException();
            }
        }
        public Thing getThing(int id_thing)
        {
            Thing thing = this.ithingDB.getThing(id_thing);
            if (thing.Id_thing == -1)
                throw new ThingNotFoundException();
            return thing;
        }
        public List<Thing> getAllThing()
        {
            return this.ithingDB.getAllThing();
        }
        public void changeRoomThing(int id_thing, int id_from, int id_to)
        {
            Thing thing = this.ithingDB.getThing(id_thing);
            if (thing.Id_thing == -1)
                throw new ThingNotFoundException();
            else
                if (thing.Id_room != id_from)
                throw new ThingNotInRoomException();
            else
            {
                Room room = this.iroomDB.getRoom(id_to);
                if (room.Id_room == -1)
                    throw new RoomNotFoundException();
                else
                {
                    this.IthingDB.changeRoomThing(id_thing, id_from, id_to);
                    thing = this.ithingDB.getThing(id_thing);
                    if (thing.Id_room != id_to)
                        throw new ChangeRoomThingErrorException();
                }
            }
        }
        public List<Thing> getFreeThing() => ithingDB.getAllThing().Where(x => !x.Id_student.HasValue).ToList();
    }
}
