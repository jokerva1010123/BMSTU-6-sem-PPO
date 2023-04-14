using Models;

namespace InterfaceDB
{
    public interface IStudentDB
    {
        void addStudent(Student student);
        List<Student> getAllStudent();
        int getIdStudentFromCode(string code);
        Student? getStudent(int id_student);
        void deleteStudent(int id_student);
        void changeStudentGroup(int id_student, string newGroup);
        void changeStudentName(int id_student, string newName);
        void changeStudent(int id_student, Student newStudent);
    }
}
