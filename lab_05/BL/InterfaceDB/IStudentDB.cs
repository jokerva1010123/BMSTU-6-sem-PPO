using Models;

namespace InterfaceDB
{
    public interface IStudentDB
    {
        void addStudent(Student student);
        List<Student> getAllStudent();
        int getIdStudentFromCode(string code);
        Student? getStudent(int id_student);
        void transferStudent(int id_student, int id_room);
        void changeStudent(int id_student, Student newStudent);
        void returnRoom(int id_studnt); 
    }
}
