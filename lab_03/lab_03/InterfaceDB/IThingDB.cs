using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_03
{
    public interface IThingDB
    {
        void addThing(Thing thing);
        void deleteThing(int id_thing);
        Thing getThing(int id_thing);
        List<Thing> getAllThing();
        void changeRoomThing(int id_thing, int id_from, int id_to);
    }
}

