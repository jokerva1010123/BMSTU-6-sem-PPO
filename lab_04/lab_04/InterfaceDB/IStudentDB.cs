namespace lab_04
{
    public interface IStudentDB
    {
        void addStudent(Student student);
        int getIdStudentFromCode(string code);
        void changeStudent(int id_student, Student newStudent);
        Student getStudent(int id_student);
        List<Student> getAllStudent();
    }
}
