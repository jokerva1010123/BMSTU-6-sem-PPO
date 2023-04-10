using System;

namespace lab_05
{
    public class UserServices
    {
        private IUserDB iuserDB;
        public IUserDB IuserDB { get => iuserDB; set => iuserDB = value; }
        public UserServices(IUserDB iuserDB)
        {
            this.iuserDB = iuserDB;
        }
        public void addUser(string login, string password, Levels levels)
        {
            if (this.iuserDB.getIdUser(login) != -1)
                throw new UserExistsException();
            this.iuserDB.addUser(login, password, levels);
        }
        public int getIdUser(string login)
        {
            int id = this.iuserDB.getIdUser(login);
            if (id == -1)
                throw new UserNotFoundException();
            else 
                return id;
        }
        public User getUser(int id)
        {
            User? user = this.iuserDB.getUser(id);
            if(user == null)
                throw new UserNotFoundException();
            else 
                return user;
        }
        public Boolean userExists(string login)
        {
            return this.iuserDB.getIdUser(login) != -1;
        }
    }
}
