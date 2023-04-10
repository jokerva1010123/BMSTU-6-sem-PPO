using lab_04Tests.DA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace lab_04.Tests
{
    [TestClass()]
    public class UserDATests
    {
        [TestMethod()]
        public void getUserTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            User tmpUser = userServices.getUser(1);
            Assert.AreEqual(tmpUser.Id, 1);
            Assert.AreEqual(tmpUser.UserLevel, Levels.STUDENT);
        }
        [TestMethod()]
        public void getUserFailTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            Assert.ThrowsException<UserNotFoundException>(() => userServices.getUser(999));
        }
        [TestMethod()]
        public void getIdUserTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            int id = userServices.getIdUser("alex");
            Assert.AreEqual(id, 1);
        }
        [TestMethod()]
        public void getIdUserFailTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            Assert.ThrowsException<UserNotFoundException>(() => userServices.getIdUser("abc"));
        }
        [TestMethod()]
        public void addUserFailTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            Assert.ThrowsException<UserExistsException>(() => userServices.addUser("alex", "alex", Levels.STUDENT));
        }
    }
}