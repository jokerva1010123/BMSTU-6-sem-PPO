using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class User
    {
        private int id;
        private string login;
        private string password;

        public int Id { get { return id; } set { id = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }

        public User()
        {
            this.id = -1;
            this.login = String.Empty;
            this.password = String.Empty;
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public User(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
    }
}
