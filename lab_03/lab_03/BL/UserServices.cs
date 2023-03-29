using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class UserServices
    {
        private IUserDB iuserDB;

        public IUserDB IuserDB { get => iuserDB; set => iuserDB = value; }

        public UserServices(IUserDB iuserDB)
        {
            this.iuserDB = iuserDB;
        }

        public void addUser(string login, string password)
        {
            this.iuserDB.addUser(login, password);
        }

        public int getIdUser(string login)
        {
            return this.iuserDB.getIdUser(login);
        }
        public User getUser(int id)
        {
            return this.iuserDB.getUser(id);
        }
    }
}
