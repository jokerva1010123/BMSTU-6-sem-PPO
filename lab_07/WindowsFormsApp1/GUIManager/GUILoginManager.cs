using System;
using BL;
using Models;
using Error;

namespace GUIManage
{
    public class GUILoginManager
    {
        private UserServices userServices;
        public GUILoginManager(UserServices userServices)
        {
            this.userServices = userServices;
        }
        public Boolean isAuthorized(string login)
        {
            return this.userServices.userExists(login);
        }
        public Levels tryAuthorize(string login, string password)
        {
            Levels levelUser = Levels.NONE;
            if (this.userServices.userExists(login))
            {
                int id  = this.userServices.getIdUser(login);
                User user = this.userServices.getUser(id);
                if (user.Password == password)
                    levelUser = user.UserLevel;
                else
                    throw new IncorrectPasswordExcept();
            }
            else 
                throw new LoginNotFoundException();
            return levelUser;
        }
        public int getIdUser(string login)
        {
            return this.userServices.getIdUser(login);
        }
    }
}
