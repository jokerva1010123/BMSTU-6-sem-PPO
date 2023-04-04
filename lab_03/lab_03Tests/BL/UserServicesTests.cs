using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03.Tests
{
    public class TestUserServices:IUserDB
    {
        private List<User> users;
        public TestUserServices(List<User> users)
        {
            this.users = users;
        }
        public void addUser(string login, string password)
        {
            int N = this.users.Count;
            this.users.Add(new User(N+1, login, password));
        }
        public User getUser(int id)
        {
            foreach(User user in this.users)
                if(user.Id == id)
                    return user;
            return new User(-1, string.Empty, string.Empty);
        }
        public int getIdUser(string login)
        {
            foreach(User user in this.users)
                if(user.Login == login)
                    return user.Id;
            return -1;
        }
    }
    [TestClass()]
    public class UserServicesTests
    {
        [TestMethod()]
        public void getUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "abc", "abc"));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            User user = userServices.getUser(1);
            Assert.AreEqual("abc", user.Login);
        }
        [TestMethod()]
        public void addUserTest()
        {
            List <User> users = new List<User>();
            users.Add(new User(1, "abc", "abc"));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            userServices.addUser("alex", "alex0612");

            User user = userServices.getUser(2);
            Assert.AreEqual(2, user.Id);
        }
        [TestMethod()]
        public void getIdUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "abc", "abc"));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            int id_user = userServices.getIdUser("abc");
            Assert.AreEqual(1, id_user);
        }
    }
}