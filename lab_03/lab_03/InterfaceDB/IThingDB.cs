using Models;

namespace InterfaceDB
{
    public interface IThingDB
    {
        void addThing(Thing thing);
        void deleteThing(int id_thing);
        Thing? getThing(int id_thing);
        List<Thing> getAllThing();
        void changeRoomThing(int id_thing, int id_from, int id_to);
    }
}

