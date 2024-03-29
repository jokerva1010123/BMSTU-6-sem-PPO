﻿using BL;
using Error;
using Models;

namespace Main
{
    internal class UserManager
    {
        private UserServices userServices;
        private string login;
        private string password;

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public UserManager(UserServices userServices)
        {
            this.userServices = userServices;
        }
        public Boolean isAuthorized(string login)
        {
            return this.userServices.userExists(login);
        }
        public Levels tryAuthorize()
        {
            Levels levelUser = Levels.NONE;
            Console.Write("Введите логин: ");
            this.login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            this.password = Console.ReadLine();
            if (this.userServices.userExists(this.login))
            {
                int id = this.userServices.getIdUser(this.login);
                User user = this.userServices.getUser(id);
                if (user.Password == this.password)
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
