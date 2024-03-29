﻿using Models;

namespace InterfaceDB
{
    public interface IRoomDB
    {
        void addRoom(Room room);
        Room? getRoom(int id_room);
        void deleteRoom(int id_room);
        List<Room> getAllRoom();
    }
}
