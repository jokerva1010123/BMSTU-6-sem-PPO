using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public interface IUserDB
    {
        void addUser(string login, string password);
        User getUser(int id);
        int getIdUser(string login);
    }
}
