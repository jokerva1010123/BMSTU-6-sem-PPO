namespace lab_05
{
    public interface IUserDB
    {
        void addUser(string login, string password, Levels levels);
        User? getUser(int id);
        int getIdUser(string login);
    }
}
