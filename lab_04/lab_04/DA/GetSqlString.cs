namespace lab_04
{
    public static class SqlStr
    {
        public static string getStrAddRoom(Room room)
        {
            return "insert into Rooms(number, roomtype) values ('" +
                room.Number.ToString() + "', " + ((int)room.RoomTypes).ToString() + ");";
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
            return "insert into Students(name, groupStudent, studentCode, id_room, date) values ('" 
                + student.Name + "', '" + student.Group + "', '" + student.StudentCode + "', " +
                student.Id_room.ToString() + ", '" + student.DataIn.ToString() + "');";
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
            return "update Students set name = '" + newStudent.Name + "', groupStudent = '" + newStudent.Group + "', studentCode = '" + 
                newStudent.StudentCode + "', id_room = " + newStudent.Id_room.ToString() + ", date = " + 
                newStudent.DataIn.ToString() + " where id_student = " + id_student.ToString() + ";";
        }
        public static string getStrTransferStudent(int id_student, int id_room)
        {
            return "update Students set id_room = " + id_room.ToString() + " where id_stdudent = " + id_student + ";";
        }
        public static string getStrAddThing(Thing thing)
        {
            return "insert into Things(code, type, id_room, id_student) values ("  
                + thing.Code.ToString() + ", '" + thing.Type.ToString() + "', " + thing.Id_room.ToString() + ", " + 
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
            return "update Things set id_room = " + id_to.ToString() + " where id_thing = " + id_thing.ToString() + ";";
        }
        public static string getStrGetIdUser(string login)
        {
            return "select id from Users where login = '" + login + "';";
        }
        public static string getStrGetUser(int id)
        {
            return "select * from Users where id = " + id.ToString() + ";";
        }
        public static string getStrAddUser(string login, string password, Levels userLevel)
        { 
            return "insert into Users(login, password, level) values ('" + login + "', '" + password + "', " + ((int)userLevel).ToString() + ");"; 
        }
    }
}
