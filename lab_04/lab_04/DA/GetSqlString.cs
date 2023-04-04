namespace lab_04
{
    public static class SqlStr
    {
        public static string getStrAddRoom(Room room)
        {
            return "insert into Rooms(id_room, number, roomtype) values ('" +
                room.Id_room.ToString() + "', '" + room.Number.ToString() + "', " + room.RoomTypes + ");";
        }
        public static string getStrGetRoom(int id_room)
        {
            return "select * from Rooms where id_room = " + id_room.ToString() + ";";
        }
        public static string getStrGetAllRoom()
        {
            return "select * from Rooms;";
        }
        public static string getStrDeleteRoom(int id_room)
        {
            return "delete from Rooms where id_room = " + id_room.ToString() + ";";
        }
        public static string getStrAddStudent(Student student)
        {
            return "insert into Students(id_student, name, group, studentCode, id_room, date) values (" +
                student.Id_student.ToString() + ", '" + student.Name + "', '" + student.Group + "', '" + student.StudentCode + "', " +
                student.Id_room.ToString() + ", " + student.DataIn.ToString() + ");";
        }
        public static string getStrGetAllStudent()
        {
            return "select * from Students";
        }
        public static string getStrGetIdStudent(string code)
        {
            return "select id_student from Students where studentCode = '" + code + "';";
        }
        public static string getStrGetStudent(int id_student)
        {
            return "select * from Students where id_student = " + id_student.ToString() + ";";
        }
        public static string getStrChangeStudent(int id_student, Student newStudent)
        {
            return "update Students set name = '" + newStudent.Name + "', group = '" + newStudent.Group + "', studentCode = '" + 
                newStudent.StudentCode + "', id_room = " + newStudent.Id_room.ToString() + ", date = " + 
                newStudent.DataIn.ToString() + " where id_student = " + id_student.ToString() + ";";
        }
        public static string getStrAddThing(Thing thing)
        {
            return "insert into Things(id_thing, code, type, id_room, id_student) valuses (" + thing.Id_thing.ToString() 
                + ", " + thing.Code.ToString() + ", '" + thing.Type.ToString() + "', " + thing.Id_room.ToString() + ", " + 
                thing.Id_student.ToString() + ");";
        }
        public static string getStrGetThing(int id_thing) 
        {
            return "select * from Things where id_thing = " + id_thing.ToString() + ";";
        }
        public static string getStrGetAllThing()
        {
            return "select * from Things";
        }
        public static string getStrDeleteThing(int id_thing)
        {
            return "delete from Things where id_thing = " + id_thing.ToString() + ";";
        }
        public static string getStrGetIdThing(int code)
        {
            return "select id_thing from Things where code = " + code.ToString() + ";";
        }
        public static string getStrChangeRoomThing(int id_thing, int id_from, int id_to)
        {
            return "insert into ThingRoomHistory (room_from, room_to, id_thing) values (" + 
                id_from.ToString() + ", " + id_to.ToString() + ", " + id_thing.ToString() + ";";
        }
        public static string getStrGetIdUser(string login)
        {
            return "select id_thing from Users where login = '" + login + "';";
        }
        public static string getStrGetUser(int id)
        {
            return "select * from Users where id = " + id.ToString() + ";";
        }
        public static string getStrAddUser(string login, string password, Levels userLevel)
        {
            return "insert into Users(login, password, level) values ('" + login + "', " + password + "', " + userLevel.ToString() + ");"; 
        }
    }
}
