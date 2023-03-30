namespace lab_03
{
    public interface IUserDB
    {
        void addUser(string login, string password);
        User getUser(int id);
        int getIdUser(string login);
    }
}
