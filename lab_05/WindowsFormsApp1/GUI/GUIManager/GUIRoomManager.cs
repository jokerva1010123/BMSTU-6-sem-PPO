using System.Collections.Generic;

namespace lab_05
{
    public class GUIRoomManager
    {
        private RoomServices roomServices;
        public GUIRoomManager(RoomServices roomServices)
        {
            this.roomServices = roomServices;
        }
        public Room GetRoom(int id)
        {
            return this.roomServices.getRoom(id);
        }
        public List <Room> getAllRoom()
        {
            return this.roomServices.getAllRoom();
        }
    }
}
