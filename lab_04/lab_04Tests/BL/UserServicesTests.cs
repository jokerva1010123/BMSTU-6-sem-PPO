using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Models;
using BL;

namespace Tests.BL
{
    public class TestUserServices : IUserDB
    {
        private List<User> users;
        public TestUserServices(List<User> users)
        {
            this.users = users;
        }
        public void addUser(string login, string password, Levels userLevel)
        {
            int N = this.users.Count;
            this.users.Add(new User(N + 1, login, password, userLevel));
        }
        public User? getUser(int id)
        {
            foreach (User user in this.users)
                if (user.Id == id)
                    return user;
            return null;
        }
        public int getIdUser(string login)
        {
            foreach (User user in this.users)
                if (user.Login == login)
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
            users.Add(new User(1, "abc", "abc", Levels.MANAGER));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            User user = userServices.getUser(1);
            Assert.AreEqual("abc", user.Login);
        }
        [TestMethod()]
        public void addUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "abc", "abc", Levels.MANAGER));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            userServices.addUser("alex", "alex0612", Levels.STUDENT);

            User user = userServices.getUser(2);
            Assert.AreEqual(2, user.Id);
        }
        [TestMethod()]
        public void getIdUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "abc", "abc", Levels.STUDENT));

            TestUserServices testUser = new TestUserServices(users);
            UserServices userServices = new UserServices(testUser);

            int id_user = userServices.getIdUser("abc");
            Assert.AreEqual(1, id_user);
        }
    }
}