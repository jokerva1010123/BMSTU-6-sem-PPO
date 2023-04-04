namespace lab_03
{
    public interface IStudentDB
    {
        void addStudent(Student student);
        void changeStudentGroup(int id_student, string newGroup);
        void changeStudetName(int id_student, string newName);
        void deleteStudent(int id_student);
        Student getStudent(int id_student);
        List<Student> getAllStudent();
        void setRoomStudent(int id_student, int id_room);
    }
}
