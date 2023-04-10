using System;

namespace lab_05
{
    public class GUIAuthManager
    {
        private string login;
        private string password;
        private UserServices userServices;
        public GUIAuthManager(UserServices userServices)
        {
            this.login = string.Empty;
            this.password = string.Empty;
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
    }
}
