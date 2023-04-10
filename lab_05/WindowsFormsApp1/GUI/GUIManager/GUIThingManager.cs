using System.Collections.Generic;

namespace lab_05
{
    public class GUIThingManager
    {
        private ThingServices thingServices;
        private StudentServices studentServices;
        private RoomServices roomServices;
        public GUIThingManager(ThingServices thingServices, StudentServices studentServices, RoomServices roomServices) 
        {
            this.thingServices = thingServices;
            this.studentServices = studentServices;
            this.roomServices = roomServices;
        }
        public List<Thing> getAllThing()
        {
            return this.thingServices.getAllThing();
        }
        public List<Thing> getFreeThing()
        {
            return this.thingServices.getFreeThing();
        }
        public void addThing(int code, string type)
        {
            this.thingServices.addThing(code, type);
        }
        public void transferThing(int code, int id_room)
        {
            int id_thing = this.thingServices.getIdThingFromCode(code);
            Thing thing = this.thingServices.getThing(id_thing);
            Room room = this.roomServices.getRoom(thing.Id_room);
            this.thingServices.changeRoomThing(id_thing, (int)room.Id_room, id_room);
        }
        public void giveStudentThing(string studentCode, int codeThing)
        {
            int id_student = this.studentServices.getIdStudentFromCode(studentCode);
            int id_thing = this.thingServices.getIdThingFromCode(codeThing);
            this.thingServices.transferStudentThing(id_student, id_thing);
        }
        public void takeStudentThing(string studentCode, int codeThing)
        {
            int id_student = this.studentServices.getIdStudentFromCode(studentCode);
            int id_thing = this.thingServices.getIdThingFromCode(codeThing);
            this.thingServices.returnThing(id_student, id_thing);
        }
        public List<Thing> getStudentThing(string studentCode) 
        {
            int id_student = this.studentServices.getIdStudentFromCode(studentCode);
            return this.thingServices.getStudentThing(id_student);
        }
    }
}
