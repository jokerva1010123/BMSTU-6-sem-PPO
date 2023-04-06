namespace lab_04.Tests
{
    static public class Obj
    {
        public static List<Room> rooms = new List<Room>
        {
            new Room(1, 528, RoomType.StudentRoom),
            new Room(2, 428, RoomType.StudentRoom),
            new Room(3, 101, RoomType.Storage)
        };
        public static List<Thing> things = new List<Thing>
        {
            new Thing(1, 228, "Chair", 1, 1),
            new Thing(2, 1234, "Table", 2, 2),
            new Thing(3, 321, "Chair", 3, -1)
        };
        public static List<Student> students = new List<Student>
        {
            new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023")),
            new Student(2, "Anton", "IU7-63", "1222222", 2, DateTime.Parse("07-02-2023")),
            new Student(3, "Makxim", "IU7-62", "1323232", 2, DateTime.Parse("05-02-2023"))
        };
    }
}